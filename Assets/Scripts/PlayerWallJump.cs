using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour
{
    Player player;
    public float wallJumpForce = 40f;
    private float timeToGetOffWall;
    public float getOffWallCooldown = 0.2f;
    public float slidingOffSlowDown = 8f;
    private bool canWallJump;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        timeToGetOffWall = 0f;
        canWallJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canWallJump && Input.GetKeyDown(KeyCode.Space))
        {
            WallJump();
        }
        if (canWallJump && Input.GetAxis("Vertical") == 1f)
        {
            timeToGetOffWall += Time.deltaTime;
            if (timeToGetOffWall > getOffWallCooldown) {
                player.zAxisMouvementAllowed = true;
            }
        }
        else
        {
            ResetGetOffWallCooldown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("WallJumpable"))
        {
            player.zAxisMouvementAllowed = false;
            player.applyGravity = false;
            player.velocity.y = player.gravity / slidingOffSlowDown;
            canWallJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("WallJumpable"))
        {
            player.zAxisMouvementAllowed = true;
            player.applyGravity = true;
            canWallJump = false;
        }
    }

    private void WallJump() {
        player.velocity.y = wallJumpForce;
        player.zAxisMouvementAllowed = true;
    }

    private void ResetGetOffWallCooldown() {
        timeToGetOffWall = 0f;
    }
}
