using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _Explosion;

    [SerializeField]
    private int Life = 3;

    public bool CanTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldActive = false;
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;

    [SerializeField]
    private GameObject _LaserPrefab;

    [SerializeField]
    private GameObject _TripleShotPrefab;

    [SerializeField]
    private GameObject _ShieldGameObject;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    [SerializeField]
    private float _Speed = 5.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject[] _engines;

    private int HitCount;

    // Use this for initialization
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();

        if (_uiManager != null)
        {
            _uiManager.UpdateLifes(Life);
        }

        /*if (_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutine();
        }*/

        HitCount = 0;

        if (_gameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOne == true)
        {
            Movement();

        #if UNITY_ANDROID
            if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire"))
            {
                Shoot();
            }

#elif UNITY_IOS
             if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire"))
            {
                Shoot();
            }

#else
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
#endif
        }

        else if (isPlayerTwo == true)
        {
            PlayerTwoMovement();

            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();

            if (CanTripleShot == true)
            {
                Instantiate(_TripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_LaserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
            }
            
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        float VerticalInput = CrossPlatformInputManager.GetAxis("Vertical"); //Input.GetAxis("Vertical");
        float HorizontalInput = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxis("Horizontal");

        if (isSpeedBoostActive == true)
        {
            transform.Translate(((Vector3.right * _Speed) * HorizontalInput) * Time.deltaTime * 1.5f);
            transform.Translate(((Vector3.up * _Speed) * VerticalInput) * Time.deltaTime * 1.5f);
        }
        else
        { 
            transform.Translate(((Vector3.right * _Speed) * HorizontalInput) * Time.deltaTime);
            transform.Translate(((Vector3.up * _Speed) * VerticalInput) * Time.deltaTime);
        }

        //For Vertical
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //For Horizontal 
        if (transform.position.x > 8.15f)
        {
            transform.position = new Vector3(8.15f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.15f)
        {
            transform.position = new Vector3(-8.15f, transform.position.y, 0);
        }

    }

    private void PlayerTwoMovement()
    {
        //Movement keys
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate((Vector3.up * _Speed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate((Vector3.right * _Speed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate((Vector3.down * _Speed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate((Vector3.left * _Speed) * Time.deltaTime);
        }
        //------------------------------- Finish Movement Keys --------------------------------

        //Speed PowerUp 
        if (isSpeedBoostActive == true)
        {
            if (Input.GetKey(KeyCode.I))
            {
                transform.Translate(Vector3.up * _Speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(Vector3.right * _Speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(Vector3.down * _Speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.J))
            {
                transform.Translate(Vector3.left * _Speed * 1.5f * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.I))
            {
                transform.Translate(Vector3.up * _Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.Translate(Vector3.right * _Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.K))
            {
                transform.Translate(Vector3.down * _Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.J))
            {
                transform.Translate(Vector3.left * _Speed * Time.deltaTime);
            }
        }

        //-------------------------------------- Restrictions ----------------------------------

        //For Vertical
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //For Horizontal 
        if (transform.position.x > 8.15f)
        {
            transform.position = new Vector3(8.15f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.15f)
        {
            transform.position = new Vector3(-8.15f, transform.position.y, 0);
        }

    }


    public void Damage()
    {
        if (isShieldActive == true)
        {
            isShieldActive = false;
            _ShieldGameObject.SetActive(false);
        }
        else
        {
            Life -= 1;
            _uiManager.UpdateLifes(Life);

            HitCount++;

            if (HitCount == 1)
            {
                _engines[0].SetActive(true);
            }
            else if (HitCount == 2)
            {
                _engines[1].SetActive(true);
            }
        }

        if (Life < 1)
        {
            Instantiate(_Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            _gameManager.GameOver = true;
        }
        
    }

    //Methods to enable de Triple Shot
    public void TripleShotPowerupON()
    {
        CanTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        CanTripleShot = false;
    }

    //Methods to enable the Speed Boost
    public void SpeedBoostON()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    //Method to enable the Shield
    public void ShieldON()
    {
        isShieldActive = true;
        _ShieldGameObject.SetActive(true);
    }
}
