using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    UnityEngine.GameObject _enemy;
    [SerializeField]
    UnityEngine.GameObject _enemyContainer;
    [SerializeField]
    PlayerBehavior _player;
    private bool _stopSpawning = false;
    [SerializeField]
    UnityEngine.GameObject _tripleShot;


    void Start()
    {
        _player = GameObject.Find("Super Mini Sparkles").GetComponent<PlayerBehavior>();
        StartCoroutine(_SpawnEnemyRoutine());
        StartCoroutine(_SpawnPowerup3ShotRoutine());
        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }
    }


    void Update()
    {

    }


    private IEnumerator _SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 4.4f, 0);
            GameObject newEnemy = Instantiate(_enemy, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);

            if (_stopSpawning == true)
            {

                break;

            }
        }

    }
    private IEnumerator _SpawnPowerup3ShotRoutine()
    {
        while (_stopSpawning == false) 
        {
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 4.4f, 0);
                GameObject newTripleShot = Instantiate(_tripleShot, posToSpawn, Quaternion.identity);
                yield return new WaitForSeconds(7.0f);
               

            }
            if (_stopSpawning == true)
            {

                break;

            }

        }
        
    }
    public void OnPlayerDeath()
    {
        _player = null;
        _stopSpawning = true;


    }
}