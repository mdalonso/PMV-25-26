using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField, Tooltip("Vida del enemigo")] int _health = 1; //vida
    [SerializeField] GameStats _gameStats;

    [SerializeField] AudioClip impactClip;
    [SerializeField] AudioClip deathClip;

    public int Health { get => _health; set => _health = value; }

    private void OnEnable()
    {
        _health = 1;
    }
    public void TakeDamage()
    {
        _health--;
        AudioSource.PlayClipAtPoint(impactClip, transform.position);

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo destruido");
        //Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathClip,transform.position);
        
        PoolManager.Instance.ReturnToPool(gameObject.GetComponent<ObjectPoolBehaviour>());

        //Sumamos los puntos al score
        _gameStats.Score += _gameStats.ScorePoints;

        
    }
}