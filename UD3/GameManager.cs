using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia única del Singleton.
    // Esta variable estática es de tipo GameManager.
    //Es una propiedad pública que creará automáticamente un campo private asociado.
    //Ese campo private debe contener un objeto que tiene asociado el script GameManager
    public static GameManager Instance { get; private set; }

    // Variable para almacenar un contador global
    //Aquí se deberían incluir todas las variables y estructuras de información que son
    //globales al juego (Ejemlos: puntuación acumulada, configuración de controles...)
    private int _globalCounter = 0;//ESte campo contará el número de enemigos que hay en el juego
    public int GlobalCounter
    {
        get => _globalCounter;
        set { _globalCounter = value; }
    }
    //Awake se ejecuta cada vez que el objeto al que pertenece el script es instanciado o activado en la escena.
    //Se ejecuta antes de Start. Start se ejecuta antes del primer frame..
    private void Awake()
    {
        // Si ya existe una instancia, destruir el nuevo objeto
        //Si instance != this es porque hay otra instancia de la clase GameManager.
        if (Instance != null && Instance != this)
        {
            //en el caso de que ya exista una instancia, el GameObject se destruye y terminamos la ejecución de Awake.
            //this.gameObject es el GameObject al que está asociado el script en ejecución.
            Destroy(gameObject);
            return;
        }

        // Asignar esta instancia y asegurarse de que no se destruya al cambiar de escena
        //Si no existe una instancia previa, la instancia será this, es decir, la instancia ejecutándose actualmente.
        Instance = this;
        //El método DontDestroyOnLoad evita que el gameobject se destruya al cambiar de escena,
        //que es el comportamiento habitual en Unity
        //Esto crea un nuevo grupo de objetos en la escena que permite desvincular el GameManager de la escena que se muestra
        DontDestroyOnLoad(gameObject);
    }

    // Método para incrementar el contador
    public void IncrementCounter()
    {
        _globalCounter++;
        Debug.Log("Contador global: " + _globalCounter);
    }
}

