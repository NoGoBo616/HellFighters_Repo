using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public Vector3 variableDirection;

    private void Start()
    {
        variableDirection = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(variableDirection * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Disparo());
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
