using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool IsJumping = anim.GetBool("IsJumping");
        bool Run = Input.GetKey("w");
        bool IsRunning = anim.GetBool("IsRunning");
        bool Jump = Input.GetKey("space"); 

        if (!IsRunning && Run) //if player presses w
        {
            anim.SetBool("IsRunning", true);
            Debug.Log("running");
        }
        if(IsRunning && !Run) // if player does not press w
        {
            anim.SetBool("IsRunning", false);
            Debug.Log("Not Running");
        }

        if(Run && Jump) // if player is running and presses jump
        {
            Debug.Log("jumps");
            anim.SetBool("IsJumping", true);
        }
        if(!Run && Jump)
        {
            anim.SetBool("IsJumping", true);

        }
        if(!Run || !Jump || !IsJumping)
        {
            Debug.Log("DoesNot");
            anim.SetBool("IsJumping", false);
        }
    }
}
