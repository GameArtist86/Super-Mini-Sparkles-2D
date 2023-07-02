using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-9f, 9f);
        transform.Translate(Vector3.down * _speed * Time.deltaTime); 

        if (transform.position.y < -4.4f)
        {
            transform.position = new Vector3(randomX, 4.4f, 0);

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            {
            Destroy(this.gameObject);
        }
if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
        
    }



