using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameManagerSO _gameManager;
    [SerializeField] int _health=1;

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

   
    public void TakeDamage()
    {
        Health--;
    }

    void Die()
    {
        Debug.Log("Game Over");
        //_gameManager.ExitGame();//Reto 4 
        UIManager.Instance.ShowGameOverScreen();
        //ExitGame();//Reto 3
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
