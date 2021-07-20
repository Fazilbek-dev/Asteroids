using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{

    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 3f;
    [SerializeField] private float _startTimeShots;


    private float _timeShots;
    bool CanGo = true;

	// Use this for initialization
	private void Start () {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
	}

    

    // Update is called once per frame
    private void Update () {
        if (CanGo)
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);

        if (transform.position == point1.position)
        {
            Transform t = point1;
            point1 = point2;
            point2 = t;
            CanGo = false;
            StartCoroutine(Waiting());
        }

        if(_timeShots <= 0)
        {
            Instantiate(_bullet, _shotPoint.transform.position, _shotPoint.transform.rotation);
            _timeShots = _startTimeShots;
        }
        else
        {
            _timeShots -= Time.deltaTime;
        }
	}

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        if (transform.rotation.y == 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
        CanGo = true;
    }
}
