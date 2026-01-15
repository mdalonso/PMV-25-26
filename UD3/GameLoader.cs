using System.Threading.Tasks;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        Debug.Log("Cargando partida...");

        await LoadGameAsync();

        Debug.Log("Partida cargada");
    }

    async Task LoadGameAsync()
    {
        string data = await Task.Run(() => LoadFromDisk());
        ApplyData(data);
    }

    string LoadFromDisk()
    {
        System.Threading.Thread.Sleep(10000);
        return "Datos del jugador";
    }

    void ApplyData(string data)
    {
        Debug.Log(data);
    }
}
