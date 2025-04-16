using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float posX;
    float posY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            posX = Random.Range(-16, 16);
            posY = Random.Range(-8, 8);
            gameObject.transform.position = new Vector2(posX, posY);
        }
    }
}
