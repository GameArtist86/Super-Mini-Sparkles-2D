using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup3Shot : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //move down at a speed of 3 (adjust in the inspector)
      transform.Translate(Vector3.down * _speed * Time.deltaTime);

      //When we leave the screen, destroy this object
      if (transform.position.y < -4.4f)
        {
            Destroy(this.gameObject);

        }

    }

    //OnTriggerCollision
    private void OnTriggerEnter2D (Collider2D other)
    {
        //Only be collectible by the player (hint: use tags)
        if (other.tag == "Player")
        {
            PlayerBehavior player = other.transform.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                //activate TripleShotActive
               player.TripleShotActive();
                //on collected, destroy this object
                Destroy(this.gameObject);
            }
        }
       

    }
   


}
