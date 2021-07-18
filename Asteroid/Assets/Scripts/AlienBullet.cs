using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    [SerializeField] private GameObject _targetPosition;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isRight;
    [SerializeField] private bool _isLeft;
    [SerializeField] private bool _isUp;
    [SerializeField] private bool _isDown;

    private void Update()
    {
        Vector2 _isWhere = Vector2.left;
        if(_isRight || (!_isLeft && !_isUp && !_isDown))
        {
            _isWhere = Vector2.left;
        }
        if (_isDown || (!_isLeft && !_isUp && !_isRight))
        {
            _isWhere = Vector2.up;
        }
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, _isWhere, _distance);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(_damage);
            }
            Destroy(this.gameObject);
        }
        transform.Translate(_isWhere * _bulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 10f);
    }
}
