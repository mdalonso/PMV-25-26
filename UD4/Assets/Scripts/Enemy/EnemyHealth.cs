using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField, Tooltip("Vida del enemigo")] int _health = 1; //vida



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
        Destroy(gameObject);
    }
}