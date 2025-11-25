using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{

    //Tipos de campos:

    int health;
    float speed;
    string namePlayer;
    int count = 1; //Los campos se pueden inicializar en la propia declaración.
    bool damage;
    char confirm;

    //Start is called before the first frame update
    //Se ejecuta al justo antes de mostrar el primer frame si el objeto al que se asocia
    //el script está activo o bien en el momento de su activación si es que no se ha ejecutado antes por estar
    //desactivado al iniciar la escena.SÓLO SE EJECUTA UNA VEZ.
    void Start()
    {
        //Esta línea imprime por consola el texto
        Debug.Log("Hello World!");


        //Los campos son accesibles por todos los métodos de la clase
        //Inicialización de campos
        health = 5;
        speed = 10.5f;//Cuando asignamos valor a una variable de tipo float es necesario poner la f.
        namePlayer = "Jugador"; //Cadenas se encierran entre comillas dobles
        damage = false;
        confirm = 'y';//Caracter se encierra entre comillas simples.

        //Debug.Log(nameInTime); // Esta línea da error al descomentarla porque nameInTime es local al método Update.

    }

    // Update is called once per frame
    // Se ejecuta al inicio de cada nuevo frame siempre que el objeto esté activo.
    void Update()
    {
        Debug.Log("Let's play!");

        //Las variables declaradas dentro de un método son locales al método, es decir,
        //sólo son visibles dentro del método y se utilizan en tareas de procesamiento interno a ese método
        string nameInTime;

        //Los campos son accesibles por todos los métodos de la clase
        //operador + con valores numéricos (suma)
        health++;
        speed++;
        count++; //--> Después cambiarlo por una llamada a IncreaseCounter()
        //operador + con cadenas (concatenación)
        nameInTime = "Jugador: "+namePlayer + " " + count;
        Debug.Log(nameInTime);

        Debug.Log("Health: "+ health + " Speed: " + speed);

        MovementManager(); //--> PAra probar esto comentar las líneas Debug.Log del Update para que no dificulten ver el resultado


    }

    //El método MoveForwart simula el movimiento hacia adelante. Lo invocaremos en el Update.
    void MoveForward()
    {
        Debug.Log("Player's moving forward");
    }
    void MoveBackward()
    {
        Debug.Log("Player's moving backward");
    }
    void MoveLeftward()
    {
        Debug.Log("Jugador se mueve a la izquierda");
    }
    void MoveRightward()
    {
        Debug.Log("El jugador se mueve a la derecha");
    }

    void IncreaseCounter()
    {
        //nameInTime contiene un nombre de jugador que depende de un contador que se incrementa en cada frame
        string nameInTime;

        count++;
        nameInTime = namePlayer + " " + count;
        Debug.Log("Nombre de Jugador:"+ nameInTime);
    }

    //Este método gestiona el movimiento del player.
    void MovementManager()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeftward();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRightward();
        }

    }


}
