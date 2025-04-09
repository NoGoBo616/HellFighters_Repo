using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion_Bala : MonoBehaviour
{
    public int rueda;
    [SerializeField] float speed = 5;
    public Vector3 variableDirection;

    private void Update()
    {
        DirectionDeterminer();
        transform.Translate(variableDirection * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Disparo());
    }

    void DirectionDeterminer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            variableDirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            variableDirection = Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            variableDirection = Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            variableDirection = Vector3.down;
        }
    }

    private IEnumerator Disparo()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        yield return null;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
