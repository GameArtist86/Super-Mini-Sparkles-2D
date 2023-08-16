using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    GameObject _shieldVisualizer;
    [SerializeField]
    private PlayerBehavior _player;

    private void Start()
    {
       _player = GameObject.Find("Super Mini Sparkles").GetComponent<PlayerBehavior>();
    }



    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.4f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 4.4f, 0);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {
            GameObject.Find("ShieldVisualizer");

            if (_shieldVisualizer != null)
            {
                PlayerBehavior player = other.transform.GetComponent<PlayerBehavior>();
                player.Damage();

            }
            return;
        }


        if (other.tag == "Player")
        {
            PlayerBehavior player = other.transform.GetComponent<PlayerBehavior>();


            if (_player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
            return;

        }
        if (other.tag == "Laser")
        {
            other.transform.GetComponent<LaserBehavior>();

            Destroy(other.gameObject);
            
            if (_player != null)
            {
                _player.AddScore(10);

            }
            Destroy(this.gameObject);
        }
    }

}