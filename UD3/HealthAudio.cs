using UnityEngine;
//Este script será un observador del evento OnDeath del player

public class HealthAudio : MonoBehaviour
{
    //Creamos una referencia al componente que contiene el evento al cual tenemos
    //que suscribirnos (este es todo el acoplamiento que introduciremos)
    //Esta referencia será inicializada desde el inspector 
    public HealthComponent playerHealth;

    void OnEnable()
    {
        //nos suscribimos al evento cuando el objeto se activa indicando qué
        //método se ejecutará como respuesta al evento
        playerHealth.OnDeath += PlayDeathSound;
    }

    void OnDisable()
    {
        //Nos desuscribimos del evento cuando el objeto se desactiva
        playerHealth.OnDeath -= PlayDeathSound;
    }

    void PlayDeathSound()
    {
        //Lógica que simula la reproducción de un sonido
        Debug.Log("Sonido de muerte");
    }
    
}

