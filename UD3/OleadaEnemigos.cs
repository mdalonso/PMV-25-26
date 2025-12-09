using UnityEngine;

public class OleadaEnemigos : MonoBehaviour
{
    //La oleada se compone de un número fijo de enemigos.
    //Estos enemigos incluidos en el array se crearán desde el inspector
    //EnemyData es un struct definido en el archivo Data.cs.
    //PAra poder crearlos desde el inspector ha tenido que especificarse System.Serializable en su declaración.
    public EnemyData[] enemigosDeLaOleada;

    void Start()
    {
        Debug.Log("Iniciando oleada:");

        // Recorremos el array
        //La propiedad Length nos devuelve la longitud del array.
        for (int i = 0; i < enemigosDeLaOleada.Length; i++)
        {
            //Se accede a cada elemento del array a través de su índice.
            EnemyData e = enemigosDeLaOleada[i];
            //El uso de llaves permite integrar valores dentro de una cadena
            Debug.Log($"Enemigo {i}: {e.type} - Vida: {e.health} - Velocidad: {e.speed}");
        }
    }
}
