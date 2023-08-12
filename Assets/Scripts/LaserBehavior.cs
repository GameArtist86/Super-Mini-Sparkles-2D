using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    [SerializeField]
    private UnityEngine.GameObject _laserPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y >= 5.5f)
        {
            //Check if object has parent
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);

            }

            //then destroy parent


            Destroy(gameObject);

        }
    }


}