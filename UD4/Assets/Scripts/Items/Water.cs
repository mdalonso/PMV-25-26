using System;
using UnityEngine;

public class Water : MonoBehaviour
{
    //El campo _speedPenalty define la penalización que se aplicará sobre la velocidad del player
    //cuando éste se esté desplazando dentro del agua.
    [SerializeField] float _speedPenalty = 0.5f;

    // Start is called before the first frame update
    public float SpeedPenalty { get { return _speedPenalty; } set { _speedPenalty = value; } }

    

    /***
     * Ejemplo de comunicación mediane eventos. **/
    //Definimos dos eventos que se dispararán bajo determinadas circunstancias
    //El método de respuesta a este evento requiere de un parámetro float (penalización sobre la velocidad del player)
    public event Action<float> OnWater;//Se disparará cuando el player entre en el agua
    public event Action<float> OnGround;//Se disparará cuando el player salga del agua

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //** si el player entra en el agua invocamos al evento para que se disparen
            //la respuesta en los sucriptores */
            //(el signo de interrogación permite comprobar si el evento está declarado, en cuyo caso se invocará.
            //Si no lo está, no se realizará la invocación.
            OnWater?.Invoke(_speedPenalty);

           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //** si el player sale del agua invocamos al evento correspondiente para que se disparen
        //la respuesta en el player como suscriptor.
        if (collision.CompareTag("Player"))
        {
            OnGround?.Invoke(_speedPenalty);
           
        }
    }
}
