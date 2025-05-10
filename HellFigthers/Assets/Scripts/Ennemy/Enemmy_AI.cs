using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemmy_AI : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Transform targetPlayer;

    void Update()
    {
        FindClosestPlayer();

        if (targetPlayer != null)
        {
            Vector2 direction = (targetPlayer.position - transform.position).normalized;

            // Movimiento hacia el jugador
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            // Rotar hacia la dirección del jugador
            RotateTowards(direction);
        }
    }

    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closestDistance = Mathf.Infinity;
        Transform closestPlayer = null;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;
            }
        }

        targetPlayer = closestPlayer;
    }

    void RotateTowards(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
