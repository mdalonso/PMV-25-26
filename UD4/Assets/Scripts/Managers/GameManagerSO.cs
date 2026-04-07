using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManagerSO : MonoBehaviour
{
    [SerializeField] GameStats gameStats;
        
    

    // Start is called before the first frame update
    void Start()
    {
        gameStats.ResetState();
        StartCoroutine(CountDownRoutine());

        
    }

    // Update is called once per frame

    IEnumerator CountDownRoutine()
    {
        while (gameStats.Time > 0)
        {
            yield return new WaitForSeconds(1);
            gameStats.Time--;
        }

        Debug.Log("Game over");

        
        //ExitGame();//Reto 4 (el juego termina al terminar la cuenta atrás)

    }

    //El método ExitGame centraliza la lógica necesaria para terminar el juego
    public void ExitGame() //Reto 4
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");//volvemos a cargar la escena
        gameStats.ResetState();//Reseteamos los valores
    }
    


}