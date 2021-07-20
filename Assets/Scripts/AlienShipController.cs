using UnityEngine;

public class AlienShipController : MonoBehaviour
{
    [SerializeField] private AlienShipController _alienPrefab;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _startTimeShots;


    private float _timeBtwShots;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(_timeBtwShots <= 0)
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
            _timeBtwShots = _startTimeShots;
        }
        else
        {
            _timeBtwShots -= Time.deltaTime;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, this._speed * Time.deltaTime);
    }

   
}
