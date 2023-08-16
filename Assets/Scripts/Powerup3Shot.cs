using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup3Shot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int _powerupID = 0;
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -4.4f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerBehavior player = other.transform.GetComponent<PlayerBehavior>();
            if (player != null)
            {


                switch (_powerupID)


                    {
                    case 0: player.TripleShotActive();
                        break;
                    case 1: player.SpeedPowerup();
                        break;
                    case 2: player.ShieldPowerup();
                        break;

                }
                
                Destroy(this.gameObject);
            }
        }


    }



}
