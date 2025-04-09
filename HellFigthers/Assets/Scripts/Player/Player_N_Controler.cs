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
    public GameObject especialVFX;

    // Start is called before the first frame update 
    void Start() 
    { 
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

    //Attack
    public void HandleAttack()
    {
        if (coolDown)
        {
            if (eresUnChico)
            {
                StartCoroutine(RagnarPunch());
            }
            else
            {
                Instantiate(atackVFX, attackPoint.position, Quaternion.identity);
                StartCoroutine(Cooldown());
            }
        }
    }
    private IEnumerator Cooldown()
    {
        coolDown = false;
        yield return new WaitForSeconds(0.5f);
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
