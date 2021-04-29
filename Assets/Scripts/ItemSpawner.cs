using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    private Vector3 spawnPoint;
    public float itemInterval = 1f;
    public bool switchControlled = false;
    public bool switchOn = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.transform.position;
        if (!switchControlled)
        {
            StartCoroutine(SpawnItem());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnOnSwitch()
    {
            Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
    }

    IEnumerator SpawnItem()
    {
        Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(itemInterval);
        StartCoroutine(SpawnItem());
    }
}
