using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody rB;
    public bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, 9, -10);
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        if (transform.eulerAngles != new Vector3(0, 0, 0)) RotationReset();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rB.AddForce(new Vector3(-10, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rB.AddForce(new Vector3(10, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space)/* && canJump == true*/)
        {
            rB.AddForce(new Vector3(0, 80, 0));
        }
    }

    private void RotationReset()
    {
        if (rB.velocity.x <= 0.2f)
        {
            rB.velocity = new Vector3(0, 0, 0);
            rB.AddForce(new Vector3(0, 50, 0));
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
