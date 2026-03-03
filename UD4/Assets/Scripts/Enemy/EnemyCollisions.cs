using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    EnemyHealth _enemyHealth;
    // Start is called before the first frame update
    void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Es necesario comprobar que la colisión se produce con un proyectil ya que
        //si no se hace esta comprobación, se restará vida siempre que se produzca una
        //colisión independientemente de con quién se produzca

        //Para ello ha sido necesario asignar el Tag Bullet al prefab Bullet.
        if (collision.CompareTag("Bullet"))
        {
            //Necesitamos una referencia a Bullet.cs para comprobar si se trata de un powerShot y actuar en consecuencia
            Bullet bullet=collision.GetComponent<Bullet>();

            //Si la colisión se produce con un proyectil, llamamos al método TakeDamage para restarle vida
            _enemyHealth.TakeDamage();

            if (!bullet.PowerShot)
            {
                //Destruimos el proyectil
                //Destroy(collision.gameObject);//Si no estamos usando un pool

                //Devolvemos el proyectil al pool
                PoolManager.Instance.ReturnToPool(collision.gameObject.GetComponent<ObjectPoolBehaviour>());
            }
            else
            {
                bullet.Health--;
            }
                     
            

        }


    }
}