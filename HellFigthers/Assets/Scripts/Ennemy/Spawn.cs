using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    int posX;
    int posY;
    public GameObject[] spawned;
    public float timeToSpawn;
    bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning == false)
        {
            StartCoroutine(Spawning());
        }
    }

    private IEnumerator Spawning()
    {
        isSpawning = true;
        int randomSpawner = Random.Range(0, spawned.Length);
        Instantiate(spawned[randomSpawner], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeToSpawn);
        posY = Random.Range(-9, 10);
        posX = Random.Range(-17, 18);
        gameObject.transform.position = new Vector2(posX, posY);
        isSpawning = false;
        yield return null;
    }
}
