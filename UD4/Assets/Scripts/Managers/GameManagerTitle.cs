using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManagerTitle : MonoBehaviour
{
    [SerializeField] AudioClip buttonClip;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(buttonClip, Vector2.zero);
        Debug.Log("Empezamos el juego");
        Invoke("LoadGame", 1f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
