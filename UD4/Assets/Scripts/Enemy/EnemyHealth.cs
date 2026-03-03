using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField, Tooltip("Vida del enemigo")] int _health = 1; //vida

    public int Health { get => _health; set => _health = value; }

    private void OnEnable()
    {
        _health = 1;
    }
    public void TakeDamage()
    {
        _health--;

        if (_health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo destruido");
        //Destroy(gameObject);
        
        PoolManager.Instance.ReturnToPool(gameObject.GetComponent<ObjectPoolBehaviour>());
    }
}