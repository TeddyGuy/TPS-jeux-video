using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    Player player;
    public Slider cooldownSlider;

    public float dashForce = 100f;
    public float dashTime = 0.25f;
    public float dashCoolDownMax = 10f;
    private float dashCoolDown;
    void Start()
    {
        player = GetComponent<Player>();
        dashCoolDown = dashCoolDownMax;
        cooldownSlider.maxValue = dashCoolDownMax;
        cooldownSlider.minValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownSlider.value = dashCoolDown;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DashIsReady())
            {
                dashCoolDown = 0f;
                StartCoroutine(Dash());
            }
        }

        dashCoolDown = Mathf.Clamp(dashCoolDown + Time.deltaTime, 0, dashCoolDownMax);
    }
    private bool DashIsReady()
    {
        return dashCoolDown == dashCoolDownMax;
    }

    private IEnumerator Dash()
    {
        float start = Time.time;
        while (Time.time < start + dashTime)
        {
            player.controller.Move(transform.forward * dashForce * Time.deltaTime);
            yield return null;
        }
    }
}
