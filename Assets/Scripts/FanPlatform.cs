using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /*
    Check the collision between the character and the fan platform. If happened, turn on the FanRun animation
    */
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            animator.Play("FanRun");
        }    
    }
}
