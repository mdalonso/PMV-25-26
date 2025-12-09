using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    // Lista de enemigos activos en la escena
    private List<GameObject> enemigos = new List<GameObject>();
    //Número máximo de enemigos que puede haber en el juego
    private int _maxEnemies = 10;
    //Número de enemigos creados hasta el momento.
    private static int _nEnemy = 0;

    // Método para agregar un enemigo a la lista
    public void AgregarEnemigo(GameObject enemigo)
    {
        if (_nEnemy < _maxEnemies)
        {
            //Si ha recibido un objeto enemigo válido (no es null) y no existe ya en la lista.
            if (enemigo != null && !enemigos.Contains(enemigo))
            {
                enemigos.Add(enemigo);  // Agrega el enemigo a la lista
                _nEnemy++;
                Debug.Log($"Enemigo {enemigo.name} agregado a la lista.");
            }
        }
        else
        {
            Debug.Log("Se ha alcanzado el número máximo de enemigos");
        }
    }

    // Método para eliminar un enemigo de la lista
    public void EliminarEnemigo(GameObject enemigo)
    {
        //Antes de eliminar, comprobamos si existe en la lista.
        if (enemigos.Contains(enemigo))
        {
            enemigos.Remove(enemigo);  // Elimina el enemigo de la lista
            Debug.Log($"Enemigo {enemigo.name} eliminado de la lista.");
            _nEnemy--;
        }
    }

    // Método para actualizar todos los enemigos
    private void ActualizarEnemigos()
    {
        foreach (var enemigo in enemigos)
        {
            if (enemigo != null)
            {
                // Lógica de actualización de cada enemigo
                // Aquí puedes hacer que cada enemigo realice una acción o comportamiento
                Debug.Log($"Actualización del enemigo {enemigo.name}");
            }
        }
    }


    private void Start()
    {

        AgregarEnemigo(new GameObject("Goblin"));
        AgregarEnemigo(new GameObject("Orco"));
    }
   

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (enemigos.Count > 0)
            {
                //Eliminamos el último enemigo de la lista.
                string noumEnemy = enemigos[enemigos.Count - 1].name;
                EliminarEnemigo(enemigos[enemigos.Count - 1]);
            }
            else Debug.Log("Lista de enemigos vacía");

        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ActualizarEnemigos();  // Llamar al método que actualiza los enemigos

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AgregarEnemigo(new GameObject("Enemigo" + (_nEnemy + 1)));  // Llamar al método que actualiza los enemigos

        }

    }

}
