using UnityEngine;

public static class EnemyFactory
{
    private static float factor = 0.1f;//Factor para acotar la dificultad en el rango 0-1

    [SerializeField] private static int _basicHealth = 1;//Vida del enemigo básico
    [SerializeField] private static int _strongHealth = 3;//Vidal del enemigo Fuerte
    public static ObjectPoolBehaviour CreateRandomEnemy(int difficulty)
    {

        PoolObjectType type = Random.value >= difficulty * factor
            ? PoolObjectType.BasicEnemy
            : PoolObjectType.StrongEnemy;

        ObjectPoolBehaviour enemy = PoolManager.Instance.GetFromPool(type); 

        //Cuando sacamos un enemigo del pool hay que restablecer sus valores por defecto
        ResetEnemy(enemy);

        return enemy;
    }

    static void ResetEnemy(ObjectPoolBehaviour enemy)
    {
        if (enemy.Type == PoolObjectType.BasicEnemy)
        {
            enemy.GetComponent<EnemyHealth>().Health = _basicHealth;
        }
        else
        {
            enemy.GetComponent<EnemyHealth>().Health = _strongHealth;
        }
    }
}
