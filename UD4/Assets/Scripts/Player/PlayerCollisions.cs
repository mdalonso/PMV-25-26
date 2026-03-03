using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerHealth _playerHealth;
    PlayerShooting _playerShooting;

    private void Awake()
    {
        _playerHealth=GetComponent<PlayerHealth>();
        _playerShooting = GetComponent<PlayerShooting>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            _playerHealth.TakeDamage();
        }
        if (collision.CompareTag("FireRateIncrease"))
        {
            _playerShooting.FireRate++;
            PoolManager.Instance.ReturnToPool(collision.gameObject.GetComponent<ObjectPoolBehaviour>());
        }
        if (collision.CompareTag("PowerShot"))
        {
            _playerShooting.PowerShotEnabled = true;//Conseguimos que el player dispare un "proyectil potente"
            PoolManager.Instance.ReturnToPool(collision.gameObject.GetComponent<ObjectPoolBehaviour>());
        }


    }


    
}
