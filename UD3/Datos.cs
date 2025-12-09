using UnityEngine;

//Tipos de enemigos disponibles
//El enum EnemyType nos permite definir lot tipos posibles de enemigos.
//Internamente a cada valor se le asigna un valor empezando por 0
//(Slime=0, Skeleton=1...)
public enum EnemyType //Los enums se serializan automáticamente en el inspector.
{
    Slime,
    Skeleton,
    Bat,
    Orc
}

//Datos básicos de un enemigo
//Usamos un struct porque estos enemigos son estáticos, no instanciables en tiempo de ejecución.
[System.Serializable]//Indica que el tipo definido (struct) puede ser serializado en el inspector.Si no se especifica no se serializará.
public struct EnemyData
{
    public EnemyType type;//Usa el enun anterior para indicar el tipo de enemigo.
    public int health;
    public float speed;
    public Color color;

    public EnemyData(EnemyType type, int health, float speed, Color color)
    {
        this.type = type;
        this.health = health;
        this.speed = speed;
        this.color = color;
    }
}
