using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float range = 10;
    public float speed = 0.1f;
    public bool reversed = false;
    private float currentPos = 0;
    private float initialPos;
    public char axis = 'x';
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.x;
        Debug.Log(initialPos);
    }

    // Update is called once per frame
    void Update()
    {
        switch(axis)
        {
            case 'x':
                movementX();
                break;
            case 'y':
                movementY();
                break;
            case 'z':
                movementZ();
                break;
            default:
                movementX();
                break;
        }
        
    }

    private void movementX()
    {
        if (!reversed)
        {
            currentPos += speed * Time.deltaTime;
            transform.position = new Vector3(currentPos + initialPos, transform.position.y, transform.position.z);
            if (currentPos >= range)
            {
                reversed = true;
            }
        }
        if (reversed)
        {
            currentPos -= speed * Time.deltaTime;
            transform.position = new Vector3(currentPos + initialPos, transform.position.y, transform.position.z);
            if (currentPos <= 0)
            {
                reversed = false;
            }
        }
    }

    private void movementY()
    {
        if (!reversed)
        {
            currentPos += speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, currentPos + initialPos, transform.position.z);
            if (currentPos >= range)
            {
                reversed = true;
            }
        }
        if (reversed)
        {
            currentPos -= speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, currentPos + initialPos, transform.position.z);
            if (currentPos <= 0)
            {
                reversed = false;
            }
        }
    }

    private void movementZ()
    {
        if (!reversed)
        {
            currentPos += speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos + initialPos);
            if (currentPos >= range)
            {
                reversed = true;
            }
        }
        if (reversed)
        {
            currentPos -= speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos + initialPos);
            if (currentPos <= 0)
            {
                reversed = false;
            }
        }
    }
}
