using UnityEngine;

public class Enemy:Character
{
    public int BulletCount {  get; set; }

    public Enemy(string name,int health,int speed, int level,int bullets=100,bool ready = true) : base(name, health, speed, level, ready)
    {
        BulletCount = bullets;
    }

    //El  método Shoot va reduciendo el número de proyectiles.
    public void Shoot()
    {
        BulletCount--;
        if (BulletCount <= 0) Debug.Log("Sin munición");
        
    }
}
