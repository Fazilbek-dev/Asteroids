using System.Collections;
using UnityEngine;

public class HorizonSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _playerPos;
    [SerializeField] private bool _isYup;
    [SerializeField] private bool _isYdown;
    [SerializeField] private bool _isXright;
    [SerializeField] private bool _isXLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_isYup)
            {
                _playerPos.transform.position = new Vector3(_playerPos.transform.position.x, -_playerPos.transform.position.y, 0);
            }
            else if(_isYdown)
            {
                _playerPos.transform.position = new Vector3(_playerPos.transform.position.x, -_playerPos.transform.position.y - 1, 0);
            }
            else if (_isXLeft)
            {
                _playerPos.transform.position = new Vector3(-_playerPos.transform.position.x - 2, _playerPos.transform.position.y, 0);
            }
            else if (_isXright)
            {
                _playerPos.transform.position = new Vector3(-_playerPos.transform.position.x + 1, _playerPos.transform.position.y, 0);
            }
        }
    }
}