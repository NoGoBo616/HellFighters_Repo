using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5;
    public Vector3 variableDirection;
    public Player_N_Controler lyria;

    private void Start()
    {
        lyria = GameObject.Find("Lyria_N").GetComponent<Player_N_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        DirectionDeterminer();
    }

    private void FixedUpdate()
    {
        transform.Translate(variableDirection * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Disparo());
    }

    void DirectionDeterminer()
    {
        if (lyria.flip)
        {
            variableDirection = Vector3.right;
        }
        else
        {
            variableDirection = Vector3.left;
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
