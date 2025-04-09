using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal_Manager : MonoBehaviour
{
    int posY;
    int posX;
    public float count;
    public bool tocado;
    public bool activo;
    public Live vidaP1;
    public Live vidaP2;
    public GameObject particulas;

    private void Start()
    {
        activo = true;
        posY = Random.Range(-9, 10);
        posX = Random.Range(-17, 18);
        gameObject.transform.position = new Vector2 (posX, posY);
        count = 0;
        particulas.gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        posY = Random.Range(-9, 10);
        posX = Random.Range(-17 , 18);
        gameObject.transform.position = new Vector2(posX, posY);
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tocado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tocado = false;
        }
    }

    private void Update()
    {
        if (tocado)
        {
            count = count + 0.1f;
        }

        if (count >= 100)
        {
            StartCoroutine(Reapear());
            count = 0;
        }
    }

    private IEnumerator Reapear()
    {
        gameObject.transform.localScale = new Vector3 (0,0,0);
        activo = false;
        vidaP1.liveCur = 1f;
        vidaP2.liveCur = 1f;
        particulas.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        gameObject.transform.localScale = new Vector3(3, 3, 3);
        activo = true;
        particulas.gameObject.SetActive(true);
        OnEnable();
        yield return null;
    }
}
