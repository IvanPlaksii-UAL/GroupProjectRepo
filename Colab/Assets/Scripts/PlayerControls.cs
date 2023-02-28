using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Rigidbody rB;
    public bool canJump = false;
    private int rotationCD = 70;

    void Start()
    {
        rB = GetComponent<Rigidbody>();  
    }


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

        
    }

    private void RotationReset()
    {
        if (rB.velocity.x <= 0.2f) rotationCD--;
        else rotationCD = 70;

        if (rotationCD == 0)
        {
            rB.velocity = new Vector3(0, 0, 0);
            rB.AddForce(new Vector3(0, 150, 0));
            canJump = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Active");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rB.AddForce(new Vector3(0, 200, 0));
            }
        }
    }
}
