using System.Collections.Generic;
using UnityEngine;


public static class Statistics
{
    //declaramos un campo estático
    private static int _maxEnemies=10;

    //Creamos una lista de objetos de tipo enemigo donde iremos almacenando todos los enemigos
    //que se van creando. Esta lista no podrá tener más de _maxEnemies.
    public static List<Enemy> enemies=new List<Enemy>();

    //Declaramos una propiedad de acceso públi al campo _maxEnemies con lógica de validación en el setter
    //para que el número de enemigos nunca sea menor que 0
    public static int MaxEnemies
    {
        get=>_maxEnemies;
        set { _maxEnemies=Mathf.Max(0,value);}
    }
}
