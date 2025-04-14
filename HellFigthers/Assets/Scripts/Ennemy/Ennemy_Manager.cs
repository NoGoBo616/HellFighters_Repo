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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            if (maldicion <= 0)
            {
                vida = vida - 1;
                Instantiate(atackVFX, attLoc.position, Quaternion.identity);
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
            maldicion = maldicion - 1;
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
        if (vida <= 0) 
        {
            gameObject.SetActive(false);
        }
    }
}
