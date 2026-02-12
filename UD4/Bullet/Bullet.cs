using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //_speed es un campo privado quue está serializado para que aparezca en el inspector
    [SerializeField] float _speed = 5;


    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

   
    private void Start()
    {
        //Para que los proyectiles no existan eternamete en el caso de que no hagan blanco
        //los destruiremos a los 5 segundos en caso de que no hayan acertado a ningún enemigo.
        Destroy(gameObject, 5);
    }
    // Update is called once per frame
    void Update()
    {
        //Movimiento del proyectil
        //transform.right es un vector unitario (longitud 1) hacia la derech. Representa esa dirección.
        //tenemos vectores unitarios que definen las 3 direcciones en el espacio:

        //Con esta línea de código aseguramos que el proyectil se mueva siempre hacia una dirección concreta
        //que en este caso es hacia la derecha.
        //(para gestionar el disparo en distintas direcciones aprovecharemos el momento de su instanciación)
        transform.position += transform.right * _speed * Time.deltaTime;


    }

   
}