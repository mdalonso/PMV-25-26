using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerHealth _playerHealth;
    PlayerShooting _playerShooting;

    [SerializeField] AudioClip takeItemClip;

    private void Awake()
    {
        _playerHealth=GetComponent<PlayerHealth>();
        _playerShooting = GetComponent<PlayerShooting>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        if (collision.CompareTag("FireRateIncrease"))
        {
            AudioSource.PlayClipAtPoint(takeItemClip, transform.position);
            _playerShooting.FireRate++;
            PoolManager.Instance.ReturnToPool(collision.gameObject.GetComponent<ObjectPoolBehaviour>());
        }
        if (collision.CompareTag("PowerShot"))
        {
            AudioSource.PlayClipAtPoint(takeItemClip, transform.position);
            _playerShooting.PowerShotEnabled = true;//Conseguimos que el player dispare un "proyectil potente"
            PoolManager.Instance.ReturnToPool(collision.gameObject.GetComponent<ObjectPoolBehaviour>());
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerHealth.TakeDamage();
        }
    }



}
