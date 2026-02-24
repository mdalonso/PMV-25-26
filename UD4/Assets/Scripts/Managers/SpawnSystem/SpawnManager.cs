using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnManager : MonoBehaviour
{
    //REferencia al Scriptable Object para poder objetener los campos que necesitemos del GameManager
    //En el spawn de enemigos necesitaremos la dificultad.
    [SerializeField] GameStats gameStats;

    //Campos necesarios para spawnear enemigos
    [Range(1, 10)][SerializeField] float spawnRate = 1.0f; //define el ritmo de spawn de los enemigos
    //Necesitamos cachear los puntos de spawneo
    //[SerializeField] private GameObject[] spawnPoints; //Si lo inicializamos en el inspector
    private GameObject[] spawnPoints; //Si lo inicializamos en el método Start

    //Campos necesarios para spawnear Checkpoints
    //El tiempo que marca el ritmo de spawn de los checkpoints
    [SerializeField] int _checkPointSpawnDelay = 8;

    //Campos necesarios para spawnear PowerUps
    [SerializeField] int _powerUpSpawnDelay = 5;//Marca el tiempo de spawneo de Powerups

    //Campos necesarios para calcular una posición aleatoria...
    //...en el caso de que el spawneo se produzca en un área circular necesitamos el radio de ese área...
    [SerializeField] float _spawnRadius = 10.0f;//Para generar una posición aleatoria dentro de un círculo

    //...Para generar una posición aleatoria dentro de un rectángulo...
    //...necesitamos una referencia al tilemap ya que necesitamos conocer sus límites
    [SerializeField] Tilemap _tilemap;//Se inicializa desde el inspector
    Vector2 min;//Almacenará las coordenadas de la esquina inferior izquierda del tilemap (límite inferior)
    Vector2 max;//Almacenará las coordenadas de la esquina superior derecha del tile map (límite superior)

    private void Start()
    {
        
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");//inicialización de las referencias a los spawnpoints
        
        TileLimits();
        
        //Lanzamiento de las corrutinas de spawn
        StartCoroutine(SpawnNewEnemy());//enemigos
        StartCoroutine(SpawnNewCheckPoint());//checkpoints
        StartCoroutine(SpawnNewPowerUp());//PowerUps
    }
    
    //Esta corrutina solicita un enemigo al Pool Manager a traves de EnemyFactory
    //y lo coloca en el spawnpoint seleccionado de forma aleatoria de entre todos los existentes
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / spawnRate);//esperamos el tiempo en función del tiempo de spawn para volver a spawnear un enemigo

            ObjectPoolBehaviour enemy= EnemyFactory.CreateRandomEnemy(gameStats.Difficulty);//Solicitamos a la fábrica de enemigos, que nos dará un enemigo según la dificultad de juego

            int randomSpawnPoint = Random.Range(0, spawnPoints.Length);//Generamos una posíción aleatoria dentro del array de spawnpoints
            Transform spawnPoint = spawnPoints[randomSpawnPoint].GetComponent<Transform>();//Sólo necesitamos la posición del spawnpoint
            enemy.GetComponent<Transform>().position=spawnPoint.position;//Colocamos el nuevo enemigo en la posición del spawnpoint seleccionado

        }
    }
    IEnumerator SpawnNewCheckPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(_checkPointSpawnDelay);
            //Generamos una posición aleatoria dentro de los límites del tilemap
            Vector2 randomPosition = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            //Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;//Generación de posición aleatoria dentro de un círculo
            //Solicitamos un checkpoint al PoolManager
            ObjectPoolBehaviour checkpoint=PoolManager.Instance.GetFromPool(PoolObjectType.CheckPoint);
            //Lo colocamos en la posición aleatoria que hemos generado 
            checkpoint.GetComponent<Transform>().position=randomPosition;

        }
    }

    IEnumerator SpawnNewPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(_powerUpSpawnDelay);

            ObjectPoolBehaviour powerUp = PowerUpFactory.CreateRandomPowerup();//Solicitamos a la fábrica de Powerups

            //Generamos una posición aleatoria dentro de los límites del tilemap
            Vector2 randomPosition = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            //Vector2 randomPosition = Random.insideUnitCircle * _spawnRadius;//Generación de posición aleatoria dentro de un círculo

            //Lo colocamos en la posición aleatoria que hemos generado 
            powerUp.GetComponent<Transform>().position = randomPosition;

        }
    }

    void TileLimits()
    {
        //Cálcular los límites exactos del tilemap para generar una posición aleatoria dentro del mismo
        //Tipo de dato BoundsInt que contiene 3 valores, número de tiles a lo alto, número de tiles a lo ancho y tamaño del tile.
        //La propiedad cellBounds de un tile map devuelve el número de tiles en el eje x, el número de tiles en el eje y y el tamaño del tile
        BoundsInt bounds = _tilemap.cellBounds;
        //CellToWordk transforma tiles en coordenadas dentro del mundo del juego
        min = _tilemap.CellToWorld(bounds.min);
        max = _tilemap.CellToWorld(bounds.max);
        Debug.Log($"Coordenadas {min} {max}");
    }

}

