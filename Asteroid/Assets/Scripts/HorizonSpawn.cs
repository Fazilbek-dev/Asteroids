using System.Collections;
using UnityEngine;

public class HorizonSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _playerPos;
    [SerializeField] private bool _isYup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_isYup)
            { 
                _playerPos.transform.position = new Vector3(_playerPos.transform.position.x, -_playerPos.transform.position.y, 0);
            }
            else
            {
                _playerPos.transform.position = new Vector3(-_playerPos.transform.position.x, _playerPos.transform.position.y, 0);
            }
        }
    }
}
