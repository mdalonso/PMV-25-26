using UnityEngine;

public class Enemy:Character
{
    //Campo público declarado mediante una propiedad autoimplementada
    //Es específico de la clase Enemy, añadiendo componentes con respecto a su clase base.
    public int BulletCount {  get; set; }

    //Se inicializa directamente en su declaración ya que este campo es independiente de las instancias.
    public static int nEnemies = 0;

    public Enemy(string name,int health,int speed, int level,int bullets=100,bool ready = true) : base(name, health, speed, level, ready)
    {
        //El resto de campos se inicializan en el constructor de la clase bas
        BulletCount = bullets;

        //Cada vez que creamos un nuevo enemigo se actualiza el contador.
        nEnemies++;
    }

    //El  método Shoot va reduciendo el número de proyectiles.
    public void Shoot()
    {
        BulletCount--;
        if (BulletCount <= 0) Debug.Log("Sin munición");
        
    }
}
