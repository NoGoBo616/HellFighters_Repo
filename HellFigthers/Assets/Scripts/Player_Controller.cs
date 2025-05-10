using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{

    // Variables
    [Header("General")]
    public int speed;
    Vector2 moveimput;
    public Rigidbody2D playerRb;
    public bool eresUnChico;

    [Header ("Flip")]
    public bool flip;
    public bool flipUp;
    public GameObject attackX;
    public Transform attXLoc;
    public Transform attYLoc;
    public GameObject lr;
    public GameObject attackY;
    public GameObject ud;
    bool leftRigth;

    [Header("Attack")]
    public GameObject escudo;
    public GameObject atackVFX;
    bool forward;
    bool coolDown;
    bool canAttack;

    [Header("Anim")]
    public Ragnar_Anim Ragnar_AnimUD;
    public Ragnar_Anim Ragnar_AnimLR;


    // Start | Update

    void Start()
    {
        escudo.SetActive(false);
        coolDown = true;
    }

    private void Update()
    {
        FlipController();
    }

    // Flip

    #region

    void FlipController()
    {
        if (moveimput.x != 0)
        {
            attackY.SetActive(false);
            lr.SetActive(true);
            attackX.SetActive(true);
            ud.SetActive(false);
            forward = true;
            leftRigth = true;
            if (moveimput.x > 0 && flip == false)
            {
                Flip();
            }
            if (moveimput.x < 0 && flip)
            {
                Flip();
            }
        }

        if (moveimput.x == 0)
        {
            attackY.SetActive(true);
            lr.SetActive(false);
            attackX.SetActive(false);
            ud.SetActive(true);
            forward = false;

            if (moveimput.y > 0 && flipUp == false)
            {
                FlipY();
            }
            if (moveimput.y < 0 && flipUp)
            {
                FlipY();
            }
        }

        if (moveimput.x == 0 && moveimput.y == 0)
        {

        }

        FlipYStoped();
    }
    void Flip()
    {
        Vector3 currentscale = transform.localScale;
        currentscale.x *= -1;
        transform.localScale = currentscale;
        flip = !flip;
    }
    void FlipY()
    {
        leftRigth = false;
        Vector3 currentscale = transform.localScale;
        currentscale.y *= -1;
        transform.localScale = currentscale;
        flipUp = !flipUp;
    }

    public void FlipYStoped()
    {
        if (moveimput.x == 0 && moveimput.y == 0)
        {
            if (leftRigth)
            {
                attackX.SetActive(true);
                lr.SetActive(true);
                attackY.SetActive(false);
                ud.SetActive(false);
                forward = true;
            }
        }
    }

#endregion

    //Movimiento

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
   
    //AttackLirya

    public void HandleEspecial()
    {
        if (eresUnChico)
        {
            StartCoroutine(DashState());
        }
    }

    //AttackRagnar

    public void HandleAttack()
    {
        if (coolDown)
        {
            if (forward == false)
            {
                Instantiate(atackVFX, attXLoc.position, Quaternion.identity);
                StartCoroutine(Cooldown());
            }
            else
            {
                Instantiate(atackVFX, attYLoc.position, Quaternion.identity);
                StartCoroutine(Cooldown());
            }
        }
    }

    //Numeradores

    private IEnumerator DashState()
    {
        speed = 50;
        yield return new WaitForSeconds(0.1f);
        speed = 10;
        yield return null;
    }

    private IEnumerator Cooldown()
    {
        coolDown = false;
        yield return new WaitForSeconds(0.5f);
        coolDown = true;
        yield return null;
    }

    #region
    //No Usados
    private IEnumerator ShieldState()
    {
        escudo.SetActive(true);
        yield return new WaitForSeconds(2);
        escudo.SetActive(false);
        yield return null;
    }

    void Patata()
    {
        if (eresUnChico)
        {
            if (canAttack)
            {
                if (forward == false)
                {
                    Ragnar_AnimUD.Attack();
                    Instantiate(atackVFX, attXLoc.position, Quaternion.identity);
                    StartCoroutine(Cooldown());
                }
                else
                {
                    Ragnar_AnimLR.Attack();
                    Instantiate(atackVFX, attYLoc.position, Quaternion.identity);
                    StartCoroutine(Cooldown());
                }
            }
        }
        else
        {
            StartCoroutine(ShieldState());
        }
    }
    #endregion

}
