using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroids _asteroidPrefab;
    [SerializeField] private float _trajectoryVariance = 15f;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private float _spawnDistance = 15f;
    [SerializeField] private int _spawnAmount = 1;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this._spawnRate, this._spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < this._spawnAmount; i++)
        {
            Vector3 spawnDeriction = Random.insideUnitSphere.normalized * this._spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDeriction;

            float variance = Random.Range(-this._trajectoryVariance, this._trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroids asteroid = Instantiate(this._asteroidPrefab, spawnPoint, rotation);
            asteroid._size = Random.Range(asteroid._minSize, asteroid._maxSize);
            asteroid.SetTrajactory(rotation * -spawnDeriction);
        }
    }
}
