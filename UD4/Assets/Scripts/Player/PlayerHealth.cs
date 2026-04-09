using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //REFERENCIAS INICIALIZADAS EN EL INSPECTOR********************************
    //Al GameManager, para...
    [SerializeField] GameManagerSO _gameManager;
    //Al spriteRenderer del objeto PlayerSprite, el cual contiene la animación del player
    //Se necesita para hacerlo parpadear cuando recibe daño.
    [SerializeField] SpriteRenderer spriteRenderer;
    //CameraController es un script Monobehaviour asociado a la cámara virtual que nos va a permitir aplicar
    //la sacudida de cámara cuando el player recibe daño
    [SerializeField] CameraController _cameraController;

    //CAMPOS *****************************
    //Vida del player
    [SerializeField] int _health=1;
    //Estado de invulnerabilidad (si true, el player es invulnerable durante el tiempo determinado por el campo invulnerableDelay)
    [SerializeField] bool invulnerability=false;
    //Tiempo que dura la invulnerabilidad del player
    int invulnerableDelay = 3;

    //EStablece el valor de referencia de la velocidad de parpadeo del player cuando está en estado invulnerable
    [SerializeField] float blinkRate = 1f;

    //Propiedades de acceso público
    public int Health { get => _health;
        set
        {
            _health = value;
            //Cuando el valor del campo cambia, se actualiza el HUD para mostrar las vidas del player en tiempo real
            UIManager.Instance.UpdateUIHealth(_health);
            if (_health <= 0)
            {
                //Si la vida del player llega a 0 el player muere
                _health = 0;
                Die();
            }
        } 
    }
    private void Start()
    {
        //Mostramos la vida del player en el HUD al iniciar el juego
        UIManager.Instance.UpdateUIHealth(_health);
    }

    //TakeDamage define lo que ocurre cuando el Player es alcanzado por un enemigo
    public void TakeDamage()
    {
        //Si el player está en estado invulnerable no se hace nada.
        //Return sirve para salir de un método cuando sea necesario sin tener que esperar a que se cumpla toda
        //la secuencia de ejecución
        if (invulnerability) return;

        Health--;
        //cuando el player recibe daño entra en estado de INVULNERABILIDAD ...
        invulnerability = true;
        //...y se lanza la corrutina que hace que ese estado de invulnerabilidad dure un tiempo específico
        StartCoroutine(MakeVulnerableAgain());

        //Cuando el player recibe daño, se produce una sacudida de cámara
        _cameraController.Shake();
        
    }

    //El método DIE implementa las acciones que se deben realizar cuando el player muere
    void Die()
    {
        Debug.Log("Game Over");//Depuración

        //ExitGame();//Reto 3
        //_gameManager.ExitGame();//Reto 4

        //Mostrar la pantalla de Game Over.
        UIManager.Instance.ShowGameOverScreen();
    }
    IEnumerator MakeVulnerableAgain()
    {
        //Durante el tiempo que dura el estado INVULNERABLE
        //el player parpadeará a una velocidad creciente
        Coroutine blinking=StartCoroutine(BlinkCoroutine());
        yield return new WaitForSeconds(invulnerableDelay);//Esperamos el tiempo definido y...
        invulnerability = false;//...retiramos la invulnerabilidad del Player haciéndolo vulnerable de nuevo.
        //cuando el player deja de ser vulnerable, deja de parpadear
        StopCoroutine(blinking);
        //Nos aseguramos de que el sprite del player queda visible cuando la rutina de parpadeo finaliza
        spriteRenderer.enabled = true;

    }
    IEnumerator BlinkCoroutine()
    {
        Debug.Log("blink");
        //t, aplicado como factor inverso a blikRate, permite modificar la velocidad de parpadeo con el transcurso del tiempo
        //de manera que esta velocidad se va incrementando
        int t = 1;
        while (true)
        {
            spriteRenderer.enabled = false;//Desactivamos el Sprite Renderer...
                                           //Para avisar visualmente al usuario de que el parpadeo va a finalizar, este parpadeo será cada vez más
                                           //rápido. Para ello utilizamos una variable blinkRate que, multiplicada por t (número de veces que va a parpadear)
                                           //cuyo valor es decreciente, hará que el tiempo que está desactivado el sprite renderer sea menor en cada parpadeo.
            yield return new WaitForSeconds(blinkRate/t);//...esperamos x tiempo...
            spriteRenderer.enabled = true;//...volvemos a activar el renderer...
            yield return new WaitForSeconds(blinkRate/t);//...volvemos a esperar X tiempo antes de la siguiente iteración que volverá a desactivar el renderer
            t++;

        }
        

    }
    //Implementación de método para terminar la ejecución del juego en caso de que el player muera
    //Esta funcionalidad se integra en el GameManagerSO en base al Reto 4
    //    public void ExitGame() //Reto 3
    //    {
    //#if UNITY_EDITOR
    //        UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //        Application.Quit();
    //#endif
    //    }
}
