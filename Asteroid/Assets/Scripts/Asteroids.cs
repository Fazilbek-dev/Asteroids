using UnityEngine;

public class Asteroids : MonoBehaviour
{

    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _maxLifeTime = 30f;
    

    public float _size = 1f;
    public float _minSize = 0.5f;
    public float _maxSize = 1.5f;


    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];

        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360f);
        this.transform.localScale = Vector3.one * this._size;

        _rb2D.mass = this._size;
    }

    public void SetTrajactory(Vector3 direction)
    {
        _rb2D.AddForce(direction * this._speed);
        Destroy(this.gameObject, this._maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        { 
            if (this._size >= this._minSize * 2.5f)
            {
                CreateSplit();
                CreateSplit();
                Score._score += 50;
            }

            if (this._size >= this._minSize * 5f)
                Score._score += 20;
            if (this._size <= this._minSize * 2.5f)
                Score._score += 100;
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.25f;

        Asteroids half = Instantiate(this, position, this.transform.rotation);
        half._size = this._size * 0.5f;
        half.SetTrajactory(Random.insideUnitSphere.normalized * this._speed);
    }
}
