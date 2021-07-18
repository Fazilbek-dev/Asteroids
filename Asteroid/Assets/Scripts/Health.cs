using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private AlienAI _startPos;
    [SerializeField] private bool _isAlien;
    [SerializeField] private AudioClip _boomSound;
    public int _health;

    private AudioSource _audio;

    private void FixedUpdate()
    {
        PlayerPrefs.SetInt("Score", Score._score);

        if (_health <= 0)
        {
            if (_isAlien)
            {
                Destroy(this.gameObject);
                Instantiate(this, _startPos.transform.position, Quaternion.identity);
                Score._score += 200;
            }

            StartCoroutine(OnDestroy());
        }
    }

    private IEnumerator OnDestroy()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(_boomSound, 0.1f);
        yield return new WaitForSeconds(_boomSound.length);
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _health -= 1;
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            _health -= 1;
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
