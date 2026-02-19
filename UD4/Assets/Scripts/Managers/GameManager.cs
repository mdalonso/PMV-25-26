using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton

    [SerializeField] int _time = 30;
    [SerializeField] int _score = 0;
    //Dado que la información del GameManager es genérica al juego, normalmente se requiere de acceso público.
    public int Time { get => _time; set => _time = value; }
    public int Score { get => _score; set => _score = value; }

    //Implementación del Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(CountDownRoutine());//Se inicia la corrutina de cuenta atrás

    }

    IEnumerator CountDownRoutine()
    {
        while (_time > 0)
        {
            yield return new WaitForSeconds(1);
            _time--;
        }
        Debug.Log("Game over");
    }
}