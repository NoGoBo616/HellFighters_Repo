using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragnar_Anim : MonoBehaviour
{
    public Player_Controller controller;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        InputManagement();
    }

    void InputManagement()
    {
        if (controller.speed >= 50)
        {
            animator.SetBool("Dash",true);
        }
        else
        {
            animator.SetBool("Dash", false);
        }
        if (controller.playerRb.velocity.magnitude != 0) 
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
