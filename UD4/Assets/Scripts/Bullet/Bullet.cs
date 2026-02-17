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
        //transform.right es un vector unitario (longitud 1) hacia la derecha con respecto a la posición LOCAL del objeto.
        //Representa esa dirección.
        //tenemos vectores unitarios que definen las 3 direcciones en el espacio: right, up y fordward

        //Con esta línea de código aseguramos que el proyectil se mueva siempre hacia una dirección concreta
        //que en este caso es hacia la derecha.
        //(para gestionar el disparo en distintas direcciones aprovecharemos el momento de su instanciación)

        transform.position += transform.right * _speed * Time.deltaTime;
    }

    //Manejo de la colisión entre el proyectil y el enemigo desde el proyectil
    //OnTriggerEnter2D es un evento que se dispara cuando dos colliders entran en contacto.
    //collision: Guarda el componente Collider2D del objeto con el que colisionará Bullet (será un Enemy)
    /*private void ontriggerenter2d(collider2d collision)
    {

        //la acción sólo se realizará si el objto con el que se colisiona es un enemy
        //para ello se utilizará el tag del enemy (se ha debido de asignar el tag previamente en tiempo de diseño)
        //si no se hiciera esta comprobación, se restaría vida al enemigo cuando el bullet colisionara con cualquier objeto
        if (collision.comparetag("enemy"))
        {
            //en caso de que efectivamente se haya colisionado con un enemigo, se ejecutará el método takedamage definido en el enemy
            //collision contiene una referencia implicita al gameobject al cual está asociado el collider.
            //(también se puede acceder de forma explícita a este gameobject mediante collision.gameobject.)

            //para ello utilizamos getcomponent. esta sentencia busca un componente de tipo enemy (que es un script), asociado
            //al gameobject del collider y llama a takedamage que es un método público definido en ese script.
            collision.getcomponent<enemyhealth>().takedamage();
            //destruímos el proyectil.
            //gameobject es el gameobject al cual está asociado este script.
            destroy(gameobject);

        }

    }*/


}