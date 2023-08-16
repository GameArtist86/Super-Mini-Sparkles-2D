
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private UnityEngine.GameObject _laserPrefab;
    [SerializeField]
    private UnityEngine.GameObject _tripleShotPrefab;
    private float _ylaserOffset = .85f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    private float _fireRate = .15f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _tripleShotActive = false;
    [SerializeField]
    private bool _shieldActive = false;
    [SerializeField]
    private UnityEngine.GameObject _shieldVisualizer;
    [SerializeField]
    private int _score;
    [SerializeField]
    private UI_Manager _uiManager;
    void Start()
    {

        transform.position = new Vector3(0, -3, 0);
        _shieldVisualizer.SetActive(false);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The SpawnManager is null");
        }
        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is null");
        }
    }
    void Update()
    {
        ControlMovement();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }
    void ControlMovement()
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
        if (_tripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else if (_tripleShotActive == false)
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y * _ylaserOffset, 0), Quaternion.identity);
        }
    }
    public void Damage()
    {
        if (_shieldActive == true)
        {
            _shieldActive = false;
            _shieldVisualizer.SetActive(false);
        }
        else if (_shieldActive == false)
        {
            if (_lives > 0)


            {
                _lives = _lives - 1;
            }
            if (_lives < 1)
            {
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
        }
        

    public void TripleShotActive()
    {
        _tripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        _tripleShotActive = false;
    }

    public void SpeedPowerup()
    {
        StartCoroutine(SpeedPowerupRoutine());

    }
    IEnumerator SpeedPowerupRoutine()
    {
        _speed *= 2;
        yield return new WaitForSeconds(5f);
        _speed = 3.5f;


    }
    public void ShieldPowerup()
    {
        _shieldActive = true;
        _shieldVisualizer.SetActive(true);

    }
    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);

    }
    //Communicate with UI Manager
}