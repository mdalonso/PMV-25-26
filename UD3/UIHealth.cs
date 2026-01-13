using UnityEngine;
public class HealthUI : MonoBehaviour
{
    //Este script será un observador del evento OnHealthChanged del player
    //Creamos una referencia al componente que contiene el evento al cual tenemos
    //que suscribirnos (este es todo el acoplamiento que introduciremos)
    //Esta referencia será inicializada desde el inspector 
    [SerializeField] private HealthComponent playerHealth;

    //
    void OnEnable()
    {
        //Nos suscribimos al evento si el objeto se activa
        //La suscripción consiste en especificar qué método se va a ejecutar cuando
        //se dispare el evento correspondiente
        playerHealth.OnHealthChanged += UpdateUI;
    }

    void OnDisable()
    {
        //Nos desuscribimos del evento si el objeto se desactiva
        playerHealth.OnHealthChanged -= UpdateUI;
    }

    void UpdateUI(int health)
    {
        //Lógica que actualiza el UI con el nuevo valor de Health
        Debug.Log("Vida actual: " + health);
    }
}

