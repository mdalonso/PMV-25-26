using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameManagerSO _gameManager;
    [SerializeField] int _health=1;
    [SerializeField] bool invulnerability=false;
    int invulnerableDelay = 3;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float blinkRate = 0.1f;

    [SerializeField] CameraController _cameraController;
    public int Health { get => _health;
        set
        {
            _health = value;
            UIManager.Instance.UpdateUIHealth(_health);
            if (_health <= 0)
            {
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

    public void TakeDamage()
    {
        if (invulnerability) return;//Si es invulnerable no se produce daño

        Health--;
        invulnerability = true;
        _cameraController.Shake();
        StartCoroutine(MakeVulnerableAgain());
        
    }

    void Die()
    {
        Debug.Log("Game Over");
        //_gameManager.ExitGame();//Reto 4 
        UIManager.Instance.ShowGameOverScreen();
        //ExitGame();//Reto 3
    }
    IEnumerator MakeVulnerableAgain()
    {
        StartCoroutine(BlinkRoutine());//Parpadeo mientras el Player es invulnerable
        yield return new WaitForSeconds(invulnerableDelay);//Esperamos un tiempo y...
        invulnerability = false;//...retiramos la invulnerabilidad del Player haciéndolo vulnerable de nuevo.
    }
    IEnumerator BlinkRoutine()
    {
        Debug.Log("blink");

       
        int t = 15;//Veces que va a parpadear. Permite gestionar la condición de salida de la corutina (OJO, NÚMERO MÁGICO)
        while (t > 0)
        {
            spriteRenderer.enabled = false;//Desactivamos el Sprite Renderer...
                                           //Para avisar visualmente al usuario de que el parpadeo va a finalizar, este parpadeo será cada vez más
                                           //rápido. Para ello utilizamos una variable blinkRate que, multiplicada por t (número de veces que va a parpadear)
                                           //cuyo valor es decreciente, hará que el tiempo que está desactivado el sprite renderer sea menor en cada parpadeo.
            yield return new WaitForSeconds(t * blinkRate);//...esperamos x tiempo...
            spriteRenderer.enabled = true;//...volvemos a activar el renderer...
            yield return new WaitForSeconds(t * blinkRate);//...volvemos a esperar X tiempo antes de la siguiente iteración que volverá a desactivar el renderer
            t--;

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
