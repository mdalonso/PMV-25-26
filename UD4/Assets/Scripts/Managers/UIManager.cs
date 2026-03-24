using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TMP_Text healthText;//Una referencia al elemento del HUD que muestra la salud del player
    [SerializeField] TMP_Text scoreText;//Referencia al elemento del HUD que muestra la puntuación actual
    [SerializeField] TMP_Text timeText;//Referencia al elemento del HUD que muestra el tiempo restante
    [SerializeField] TMP_Text finalScoreText;//REferencia al elemento de la pantalla de GameOver que muestra la puntuación final

    [SerializeField] GameStats gameStats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Método para actualizar la puntuación en el HUD
    public void UpdateUIScore(int newScore)
    {
        scoreText.text=newScore.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
