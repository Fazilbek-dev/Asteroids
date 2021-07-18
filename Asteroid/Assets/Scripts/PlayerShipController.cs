using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    
    [SerializeField] private float _speedShip = 1f;
    [SerializeField] private float _turnSpeed = 1f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _startTimeBtwShots;
    [SerializeField] private float _offset;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _motorSound;
    [SerializeField] private GameObject _fireFromShip;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _buttonLose;
    [SerializeField] private Health _health;
    private AudioSource _audioSource;

    private float _timeBtwShots;
    private Rigidbody2D _rb2D;
    private bool _isGo;
    private float _rotateShip;

    private void Awake()
    {
        _buttonLose.SetActive(false);
        _health = GetComponent<Enemy>();
        _audioSource = GetComponent<AudioSource>();
        _rb2D = GetComponent<Rigidbody2D>();
        _fireFromShip.SetActive(false);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("MouseOn") >= 1)
        {
            Vector3 deference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            float rotZ = Mathf.Atan2(deference.y, deference.x) * Mathf.Rad2Deg;
            Quaternion _rotZ = Quaternion.Euler(0, 0, rotZ + _offset);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, _rotZ, _rotSpeed * Time.deltaTime);
        }

        _isGo = Input.GetAxis("Vertical") > 0;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            enabled = false;
            _menu.SetActive(true);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _rotateShip = -0.5f;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rotateShip = 0.5f;
        }
        else
            _rotateShip = 0f;
        if(_timeBtwShots <= 0)
        {
            if ((Input.GetKeyDown(KeyCode.Space) && (PlayerPrefs.GetInt("MouseOn") < 1) ) || (Input.GetMouseButton(0) && (PlayerPrefs.GetInt("MouseOn") >= 1) ))
            {
                GameObject bullet = ObjectPool._sharedInstance.GetPooledObject();
                if(bullet != null)
                {
                    bullet.transform.position = this._shotPoint.position;
;                   bullet.transform.rotation = this._shotPoint.rotation;
                    bullet.SetActive(true);
                }
                _audioSource.clip = _shotSound;
                _audioSource.PlayOneShot(_shotSound, 0.1f);
                _timeBtwShots = _startTimeBtwShots;
            }
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if ((_isGo && (PlayerPrefs.GetInt("MouseOn") < 1)) || (Input.GetMouseButton(1) && (PlayerPrefs.GetInt("MouseOn") >= 1)))
        {
            _rb2D.AddForce(this.transform.up * this._speedShip);
            _audioSource.clip = _motorSound;
            _audioSource.PlayOneShot(_motorSound, 0.01f);
            _fireFromShip.SetActive(true);
        }
        else
            _fireFromShip.SetActive(false);

        if(_health._health <= 0)
        {
            _buttonLose.SetActive(true);
        }

        if (_rotateShip != 0f)
        {
            _rb2D.AddTorque(_rotateShip * this._turnSpeed);
        }
    }
}
