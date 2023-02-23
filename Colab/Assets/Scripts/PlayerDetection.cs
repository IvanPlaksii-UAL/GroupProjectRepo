using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    PlayerControls reftoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        reftoPlayer = FindObjectOfType<PlayerControls>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reftoPlayer.canJump = true;
        }
        else reftoPlayer.canJump = false;
    }
}
