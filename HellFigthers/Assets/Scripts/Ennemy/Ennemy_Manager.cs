using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Ennemy : MonoBehaviour
{
    public int vida;
    public int maldicion;
    public float attack;
    public GameObject fueguito;
    public GameObject atackVFX;
    public Transform attLoc;
    public GameObject sprite;
    public Vector3 spriteScale;
    bool canAttack;
    public AudioClip[] sounds;
    private AudioSource audioSource;
    public GameManager gameManager;
    public int puntaje;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteScale = sprite.gameObject.transform.localScale;
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            if (maldicion <= 0)
            {
                vida = vida - 1;
                Instantiate(atackVFX, attLoc.position, Quaternion.identity);
                StartCoroutine(GameFeel());
                audioSource.PlayOneShot(sounds[0]);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameObject player = collision.gameObject;
                Live playerLive = collision.gameObject.GetComponent<Live>();
                playerLive.Damage(attack);
                audioSource.PlayOneShot(sounds[1]);
            }
        }
        
        if (collision.gameObject.CompareTag("Purification"))
        {
            if (maldicion >= 0)
            {
                maldicion = maldicion - 1;
                StartCoroutine(GameFeel());
                audioSource.PlayOneShot(sounds[2]);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           if (canAttack)
            {
                GameObject player = collision.gameObject;
                Live playerLive = collision.gameObject.GetComponent<Live>();
                playerLive.Damage(attack);
                StartCoroutine(Attack());
            }
        }
    }

    private void Update()
    {
        if (maldicion > 0)
        {
            fueguito.gameObject.transform.localScale = new Vector3(5, 5, 5);
        }
        else
        {
            fueguito.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        if (vida <= 0 && maldicion <= 0) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        gameManager.puntos = gameManager.puntos + puntaje;
        Debug.Log(gameManager.puntos);
        audioSource.PlayOneShot(sounds[3]);
        Destroy(gameObject);
    }

    private IEnumerator GameFeel()
    {
        sprite.gameObject.transform.localScale = new Vector3 (0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sprite.gameObject.transform.localScale = spriteScale; 
        yield return null;
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        sprite.gameObject.transform.localScale = spriteScale * 1.2f;
        yield return new WaitForSeconds(0.1f);
        sprite.gameObject.transform.localScale = spriteScale;
        yield return new WaitForSeconds(0.2f);
        canAttack = true;
        yield return null;
    }
}
