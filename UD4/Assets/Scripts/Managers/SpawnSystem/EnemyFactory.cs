using Unity.VisualScripting;
using UnityEngine;

public static class EnemyFactory
{
    private static float factor = 0.1f;//Factor para acotar la dificultad en el rango 0-1
    public static ObjectPoolBehaviour CreateRandomEnemy(int difficulty)
    {

        PoolObjectType type = Random.value >= difficulty * factor
            ? PoolObjectType.BasicEnemy
            : PoolObjectType.StrongEnemy;

        ObjectPoolBehaviour enemy = PoolManager.Instance.GetFromPool(type); 

        return enemy;
    }
}
