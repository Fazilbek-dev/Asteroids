using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _whatIsSolid;
    [SerializeField] private ParticleSystem _particleOffset;
    [SerializeField] private AudioClip _shotSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, _distance, _whatIsSolid);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<Health>().TakeDamage(_damage);
            }
            gameObject.SetActive(false);
        }
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
        StartCoroutine(DestroyBullet());
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
