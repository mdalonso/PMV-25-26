using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> enemigos= new List<GameObject>();
    private int _maxEnemies = 10;

    private static int _nEnemy = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AgregarEnemigo("Goblin");
        AgregarEnemigo("Orco");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AgregarEnemigo("Enemigo"+(_nEnemy+1));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (enemigos.Count > 0)
            {
                //string nombreEnemigo = enemigos[enemigos.Count-1].name;
                EliminarEnemigo(enemigos[enemigos.Count-1]);
                Debug.Log("Numero de elementos de la lista " + enemigos.Count);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MostrarInfoEnemigos();
        }

    }

    public void AgregarEnemigo(string enemyName)
    {
        if (_nEnemy < _maxEnemies)
        {
            GameObject e = new GameObject(enemyName);
            if (!enemigos.Contains(e))
            {
                enemigos.Add(e);
                _nEnemy++;
                Debug.Log($"Enemigo {e.name} agregado a la lista");
            }
        }
        else
        {
            Debug.Log("Se ha alcanzado el número máximo de enemigos");

        }
    }

    public void EliminarEnemigo(GameObject enemigo)
    {
        if (enemigos.Count == 0) Debug.Log("La lista está vacía");
        else
        {
            if (enemigos.Contains(enemigo))
            {
                enemigos.Remove(enemigo);
                Debug.Log($"Enemigo {enemigo.name} eliminado de la lista");
                _nEnemy--;
                Destroy(enemigo);
            }
        }
    }

    public void MostrarInfoEnemigos()
    {
        foreach (var enemigo in enemigos)
        {
            if (enemigo != null)
            {
                Debug.Log($"Informacion del enemigo: {enemigo.name}");
            }
        }
    }
}

