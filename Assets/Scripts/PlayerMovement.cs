using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laseerPrefab;
    [SerializeField]
    private float y = .8f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    private float _fireRate = .15f;
    [SerializeField]
    private int _lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        controlMovement();
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire) 
        {
            FireLaser();
        }
    }
    void controlMovement()

    {
        
       
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);



        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, 0);

        }
        if (transform.position.x >= 9f)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9f)
        {
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laseerPrefab, new Vector3(transform.position.x, transform.position.y * y, 0), Quaternion.identity);

    }
    public void Damage()
    {
        
        if (_lives > 0) 
        {
        _lives = _lives - 1;
        }
        else if (_lives == 0)
        {
            Destroy(this.gameObject);
        }
    }
}

          
