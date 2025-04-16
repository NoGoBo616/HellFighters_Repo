using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_N_Controler : MonoBehaviour
{
    // Variables
    public int speed;
    Vector2 moveimput;
    public Rigidbody2D playerRb;
    public bool eresUnChico;
    public bool flip;
    public Transform attackPoint;
    bool coolDown;
    public GameObject atackVFX;
    public GameObject atackVFX2;
    public GameObject especialVFX;
    public Animator animator;
    public float TCD;

    // Start is called before the first frame update 
    void Start() 
    { 
        animator = GetComponent<Animator>();
        especialVFX.SetActive(false);
        coolDown = true;
    }  
     
    // Update is called once per frame 
    void Update() 
    { 
        if (moveimput.x > 0 && flip == false)
        {
            Flip();
        }
        if (moveimput.x < 0 && flip)
        {
            Flip();
        }

        MoveAnim();
    }

    //Flip
    void Flip()
    {
        Vector3 currentscale = transform.localScale;
        currentscale.y *= -1;
        transform.localScale = currentscale;
        flip = !flip;
    }

    //Move
    public void HandleMovement(InputAction.CallbackContext context)
    {

        moveimput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        playerRb.velocity = new Vector3(moveimput.x * speed, moveimput.y * speed, 0);
    }

    void MoveAnim()
    {
        if (moveimput == new Vector2(0, 0))
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }
        
        if (eresUnChico)
        {
            if (speed >= 50)
            {
                animator.SetBool("Dash", true);
            }
            else
            {
                animator.SetBool("Dash", false);
            }
        }
        else
        {

        }
    }

    //Attack
    public void HandleAttack()
    {
        if (coolDown)
        {
            if (eresUnChico)
            {
                animator.SetTrigger("Attack");
                StartCoroutine(RagnarPunch());
                StartCoroutine(Cooldown());
            }
            else
            {
                if (flip)
                {
                    Instantiate(atackVFX, attackPoint.position, Quaternion.identity);
                    StartCoroutine(Cooldown());
                }
                else
                {
                    Instantiate(atackVFX2, attackPoint.position, Quaternion.identity);
                    StartCoroutine(Cooldown());
                }
                
            }
        }
    }
    private IEnumerator Cooldown()
    {
        coolDown = false;
        yield return new WaitForSeconds(TCD);
        coolDown = true;
        yield return null;
    }

    private IEnumerator RagnarPunch()
    {
        especialVFX.SetActive(true);
        yield return new WaitForSeconds(1);
        especialVFX.SetActive(false);
        yield return null;
    }

    //Especial
    public void HandleEspecial()
    {
        if (eresUnChico)
        {
            StartCoroutine(DashState());
        }
        else
        {
            StartCoroutine(ShieldState());
        }
    }

    private IEnumerator DashState()
    {
        speed = 50;
        yield return new WaitForSeconds(0.1f);
        speed = 10;

        yield return null;
    }

    private IEnumerator ShieldState()
    {
        especialVFX.SetActive(true);
        yield return new WaitForSeconds(2);
        especialVFX.SetActive(false);
        yield return null;
    }
} 
