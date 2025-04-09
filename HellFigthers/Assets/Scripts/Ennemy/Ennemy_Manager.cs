using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Ennemy : MonoBehaviour
{
    public int enemigo;
    //GameObject[] sprites; 
    public int vida;
    public int maldicion;
    public float attack;
    public GameObject fueguito;
    public GameObject atackVFX;
    public Transform attLoc;

    private void OnEnable()
    {
        enemigo = Random.Range(1, 3);

        if (enemigo == 1 ) 
        {
            //sprites[0].gameObject.SetActive(true);
            vida = 1; maldicion = 0;
            attack = 0.1f;
        }
        if (enemigo == 2)
        {
            //sprites[1].gameObject.SetActive(true);
            vida = 1; maldicion = 1;
            attack = 0.1f;
        }
        if (enemigo == 3)
        {
            //sprites[2].gameObject.SetActive(true);
            vida = 1; maldicion = 1;
            attack = 0.1f;
        }
        if (enemigo == 4)
        {
            //sprites[3].gameObject.SetActive(true);
            vida = 2; maldicion = 1;
            attack = 0.3f;
        }
        if (enemigo == 5)
        {
            //sprites[4].gameObject.SetActive(true);
            vida = 2; maldicion = 1;
            attack = 0.3f;
        }
        if (enemigo == 6)
        {
            //sprites[5].gameObject.SetActive(true);
            vida = 0; maldicion = 3;
            attack = 0.3f;
        }
        if (enemigo == 7)
        {
            //sprites[6].gameObject.SetActive(true);
            vida = 3; maldicion = 1;
            attack = 0.7f;
        }
        if (enemigo == 8)
        {
            //sprites[7].gameObject.SetActive(true);
            vida = 3; maldicion = 1;
            attack = 0.7f;
        }
    }

    

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
            Destroy(gameObject);
        }
    }
}
