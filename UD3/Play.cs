using UnityEngine;

public class Play : MonoBehaviour
{
    Character personaje;

    //Es conveniente evitar los "valores mágicos" asignados literalmente. Por eso definimos campos públicos que
    //pueden ser serializados.

    public string namePersonaje = "Personaje";
    public int healthPersonaje = 10;
    public int speedPersonaje = 5;
    public int levelPersonaje = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = new Character(namePersonaje,healthPersonaje,speedPersonaje,levelPersonaje);//Los valores mágicos son una mala práctica. Mejor, serializados.

        Debug.Log("Nombre: "+personaje.namePlayer);//Podemos acceder directamente porque namePlayer es un campo público de la clase Character.
        //Debug.Log(personaje._health);//Esto da error de sintaxis porque no hay acceso al campo por ser private.
        Debug.Log("Health: "+personaje.Health);//Se accede a través de la propiedad
        Debug.Log("Speed: "+personaje.speed);//Se accede a través de la propiedad
        Debug.Log("Level: "+personaje.Level);//Se accede a través de la propiedad

    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            personaje.Health++;//Hace uso del setter
            Debug.Log("Salud Incrementada: "+personaje.Health);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            personaje.Level+=100;//Hace uso del setter
            Debug.Log("Nivel incrementado: "+personaje.Level);
        }


    }
}
