using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] int _speed = 3;//velocidad del movimiento
    Transform _player;//Almacenará la posición del player


    void Start()
    {
        //Para hacer que el enemigo se dirija hacia el player de forma automatizada
        //necesitamos conocer en todo momento la ubicación del player para
        //definir un vector direccional entre su posición y la posición del Enemigo
        //Este vector definirá el movimiento del enemigo.
        //Necesitamos conocer la posición del player desde el principio, por eso lo
        //incluimos en el método Start
        //Utilizamos el operador de propagación de nulabilidad (?.) para evitar posibles errores si el objeto "Player" no se encuentra
        //Búsqueda por tipo...
        //_player=FindFirstObjectByType<PlayerMovement>()?.transform;//Localizar un objeto con FindOBjectOfType

        //Búsqueda global por nombre...
        //_player = GameObject.Find("Player") ?. transform;

        //Búsqueda por tag...
        _player=GameObject.FindGameObjectWithTag("Player")?.transform;



    }

    // Update is called once per frame
    void Update()
    {
        //movimiento automático del Enemy hacia el Player.
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (_player != null)
        {
            //Obtenemos el vector de dirección (destino - origen, si no se moverá en dirección contraria)
            Vector2 direction = _player.position - transform.position;

            //Aplicamos el vector de dirección a la posición del Enemy
            //Hay que hacer Casting porque el vector de dirección se ha definido como un Vector2 y necesitamos
            //un Vector3
            transform.position += (Vector3)direction.normalized * Time.deltaTime * _speed;
        }


    }

}
