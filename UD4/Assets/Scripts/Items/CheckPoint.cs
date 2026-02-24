using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] int _addedTime = 10;

    public int AddedTime { get => _addedTime; set => _addedTime = value; }

    [SerializeField] GameStats _gameStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.Instance.Time += _addedTime;//Singleton (hay que meter el campo time con su propiedad en el Singleton)
            _gameStats.Time += _addedTime;//Scriptable object
            
            //Devolvemos el checkpoint al pool correspondiente una vez ha sido utilizado
            PoolManager.Instance.ReturnToPool(gameObject.GetComponent<ObjectPoolBehaviour>());
        }
    }


}
