using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawned;
    public float timeToSpawn;
    bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
        Recuento();
    }

    void Recuento()
    {
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning == false)
        {
            int randomSpawner = Random.Range(0, spawned.Length);
            Instantiate(spawned[randomSpawner], transform.position, Quaternion.identity);
            StartCoroutine(Spawning());
        }
    }

    private IEnumerator Spawning()
    {
        isSpawning = true;
        yield return new WaitForSeconds(timeToSpawn);
        isSpawning = false;
        yield return null;
    }

    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(30);
        timeToSpawn = timeToSpawn - 0.1f;
        Recuento(); 
        yield return null;
    }
}
