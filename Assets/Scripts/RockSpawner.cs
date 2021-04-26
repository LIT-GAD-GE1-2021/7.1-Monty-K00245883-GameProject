using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    private Vector3 spawnPoint;
    public float rockInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.transform.position;
        StartCoroutine(SpawnRock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRock()
    {
        Instantiate(rockPrefab, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(rockInterval);
        StartCoroutine(SpawnRock());
    }
}
