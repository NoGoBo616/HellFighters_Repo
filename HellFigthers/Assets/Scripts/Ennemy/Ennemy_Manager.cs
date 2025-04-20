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

    private void Start()
    {
        spriteScale = sprite.gameObject.transform.localScale;
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
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameObject player = collision.gameObject;
                Live playerLive = collision.gameObject.GetComponent<Live>();
                playerLive.Damage(attack);
            }
        }
        
        if (collision.gameObject.CompareTag("Purification"))
        {
            if (maldicion >= 0)
            {
                maldicion = maldicion - 1;
                StartCoroutine(GameFeel());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Live playerLive = collision.gameObject.GetComponent<Live>();
            playerLive.Damage(attack);
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
        Destroy(gameObject);
    }

    private IEnumerator GameFeel()
    {
        sprite.gameObject.transform.localScale = new Vector3 (0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        sprite.gameObject.transform.localScale = spriteScale; 
        yield return null;
    }
}
