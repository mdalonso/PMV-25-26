using UnityEngine;
//Este script nos permite testear el patrón Observer que involucra a los scripts:
//- HealthComponent
//- HealthUI
//- HealthAudio

public class TestPlayerComponent : MonoBehaviour
{
    //Creamos una referencia al healthComponent el cual contiene el comportamiento que dispara las notificaciones
    private HealthComponent healthComponent;
    private void Awake()
    {
        //Inicializamos las referencias
        //GetComponent permite localizar un componente dentro del mismo GameObject
        healthComponent = GetComponent<HealthComponent>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Forzamos que se produzca un daño
            healthComponent.TakeDamage(2);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Forzamos que se produzca la muerte del jugador
            healthComponent.TakeDamage(100);
        }
    }
}
