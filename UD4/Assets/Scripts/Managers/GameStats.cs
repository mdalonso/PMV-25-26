using UnityEngine;
//La directiva CreateAssetMenu permite crear una nueva opción de menú dentro del menú Assets.
//- fileName: Será el nombre por defecto que tendrá un nuevo asset creado a través de esta opción.
//- nemuName: Será la opción de menú. Se pueden espedificar submenús separando la ruta mediante la barra /
[CreateAssetMenu(fileName = "newGameStats", menuName = "Scriptable Objects/GameStats")]
public class GameStats : ScriptableObject
{
    [SerializeField] int _initialTime = 30;
    [SerializeField] int _initialScore = 0;//Inicialización de los puntos acumulados por el jugador
    [SerializeField][Range(1, 10)]  int _difficulty = 1;
    

    [SerializeField] int _time = 30;

    [SerializeField] int _score = 0;//Acumula los puntos del player
    [SerializeField] int _scorePoints = 100;//Puntos que se acumularán cada vez que un enemigo muera

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            UIManager.Instance.UpdateUIScore();
        }
    }
    //public int ScorePoints { get => _scorePoints; set => _scorePoints = value; }
    public int Time
    {
        get => _time;
        set
        {
            _time = value;
            UIManager.Instance.UpdateUITime();
        }
    }
    public int Difficulty { get => _difficulty; }
    public int ScorePoints { get => _scorePoints; }

    public void ResetState()
    {
        Time = _initialTime;
        Score = _initialScore;
    }
}
