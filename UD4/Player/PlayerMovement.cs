using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveDirection; //Este será el vector que determinará la dirección del movimiento
    [SerializeField] float _speed = 5;

    GatherInput input; //Movimiento con Input System

    Rigidbody2D rb;//Para el movimiento utilizando Rigid Body (física)

    private void Awake()
    {
        //Inicialización de referencias (no se van a usar en todos los casos)
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<GatherInput>();
    }
   
    // Update is called once per frame
    void Update()
    {
        //Descomentar la siguiente línea para probar el movimiento físico con rigid body
        //y comentar la llamada al método MovePlayerRigidBody
        MovePlayerAxisSum();
        //MovePlayerAxisTranslate();
    }
    private void FixedUpdate()
    {
        //MovePlayerRigidBody();
    }

    void GetMovementVector()
    {
        //Podemos obtener el vector de dirección utilizando el Input Manager
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        //Obtención del vector de dirección utilizando el Input System
        //moveDirection = input.Movimiento;
    }
    void MovePlayerAxisSum()
    {
        //MOVIMIENTO DEL OBJETO SUMANDO UN VECTOR A LA POSICIÓN.
        GetMovementVector();

        //Podemos aplicar el movimiento sumando el vector de dirección a la posición actual...
        //(hay que normalizar el vector para que no vaya más rápido en diagonal que en línea recta
        transform.position += moveDirection.normalized*Time.deltaTime*_speed;
       
    }
    void MovePlayerAxisTranslate()
    {
        GetMovementVector();

        //Podemos aplicar el movimiento mediante el método Translate
        transform.Translate(moveDirection.normalized * Time.deltaTime * _speed);
    }
    void MovePlayerRigidBody()
    {

        GetMovementVector();
        
        rb.linearVelocity=moveDirection.normalized*_speed;

    }

    
    

}