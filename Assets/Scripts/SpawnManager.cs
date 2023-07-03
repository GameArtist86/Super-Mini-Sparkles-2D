using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
        GameObject _enemyContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine()); 
    }

    // Update is called once per frame
    void Update()
    {
    }

   [SerializeField]
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 4.4f, 0);
            Instantiate(enemy, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

    }
}
