using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    //Se definen los eventos que deben ser observados para generar un comportamiento
    //automático en los observadores.
    //Los eventos deben ser públicos ya que los observadores deben poder suscribirse a ellos

    //(Los objetos de tipo evento sólo pueden ser disparados desde su propietario)
    //Evento OnHealthChanged se disparará cuando cambie el valor de la vida del personaje (health). 
    //Y enviará un valor entero al observador
    public event Action<int> OnHealthChanged;
    //Evento OnDeath se disparará cuando el personaje muera (health=0)
    public event Action OnDeath;

    //En el momento de creación del objeto se inicializa la vida al máximo 
    void Awake()
    {
        currentHealth = maxHealth;
    }

    //TakeDamage resta vida al personaje y notifica a los observadores
    public void TakeDamage(int damage)
    {
        //Al recibir daño se actualiza la vida de personaje...
        currentHealth -= damage;
        //...y se dispara el evento correspondiente enviando el valor de currentHealth
        //El signo ? permite comprobar previamente si este evento tiene suscriptores
        //En caso de no tener suscriptores (OnHealthChanged==null), el evento no se diispara
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
            //Si el personaje muere se invoca al método OnDeath sólo si tiene suscriptores
            OnDeath?.Invoke();
    }
}

