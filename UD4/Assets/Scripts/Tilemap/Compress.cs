using UnityEngine;
using UnityEngine.Tilemaps;

public class Compress : MonoBehaviour
{
    //Este script recorta las dimensiones del tilemap a la zona que contiene tiles
    //Es necesario asociar este script a tilemap
    Tilemap tilemap;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tilemap.CompressBounds();
    }
}
