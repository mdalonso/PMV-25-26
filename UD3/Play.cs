using UnityEngine;

public class Play : MonoBehaviour
{
    Character personaje;
    Player player;
    Enemy enemy;

    //Es conveniente evitar los "valores mágicos" asignados literalmente. Por eso definimos campos públicos que
    //pueden ser serializados.

    public string namePersonaje = "Personaje";
    public int healthPersonaje = 10;
    public int speedPersonaje = 5;
    public int levelPersonaje = 1;
    public bool activoPersonaje = true;

    //Campos serializados para inicializar el objeto PLAYER
    public string namePlayer = "Player con Herencia";
    public int healthPlayer = 20;
    public int speedPlayer = 10;
    public int levelPlayer = 1;
    public int strengthPlayer = 5;
    public bool readyPlayer = false;

    //Campos serializados para inicializar el objeto ENEMY
    public string nameEnemy = "Enemigo";
    public int healthEnemy = 20;
    public int speedEnemy = 10;
    public int levelEnemy = 1;
    public int bulletsEnemy = 5;

    //Configuración para un enemigo genérico
    public string nameEnemyG = "Enemigo";
    public int healthEnemyG = 10;
    public int speedEnemyG =5;
    public int levelEnemyG = 1;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personaje = new Character(namePersonaje,healthPersonaje,speedPersonaje,levelPersonaje,activoPersonaje);//Los valores mágicos son una mala práctica. Mejor, serializados.

        Debug.Log("INICIALIZACIÓN DEL PERSONAJE BÁSICO");//Podemos acceder directamente porque namePlayer es un campo público de la clase Character.
        Debug.Log("Nombre: "+personaje.NamePlayer);//Podemos acceder directamente porque namePlayer es un campo público de la clase Character.
        //Debug.Log(personaje._health);//Esto da error de sintaxis porque no hay acceso al campo por ser private.
        //Debug.LogINICIALIZACIÓN DEL PERSONAJE BÁSICO"error de sintaxis porque no hay acceso al campo por ser private.
        Debug.Log("Health: "+personaje.Health);//Se accede a través de la propiedad
        Debug.Log("Speed: "+personaje.Speed);//Se accede a través de la propiedad
        //Debug.Log("Level: "+personaje.Level);//Se accede a través de la propiedad (deja de ser accesible cuando cambiamos el campo _level por una propiedad auto-implementada
        personaje.ShowMessage();

        //Probamos a pasar readyPlayer al constructor y a no pasárselo para ver el efecto del valor por defecto en el constructor
        player=new Player(namePlayer,healthPlayer,speedPlayer,levelPlayer,strengthPlayer);
        //player=new Player(namePlayer,healthPlayer,speedPlayer,levelPlayer,strengthPlayer,readyPlayer);

        Debug.Log("INICIALIZACIÓN DEL PLAYER CON HERENCIA");
        Debug.Log("Name player: " + player.NamePlayer);
        Debug.Log("Health player: " + player.Health); //Accedemos al campo privado health mediante la propiedad Health (getter)
        Debug.Log("Speed player: " + player.Speed);
        //Debug.Log("Level player: " + player._level);//Esta línea produce un error ya que _level es protected
        Debug.Log("Level player: " + player.Level);
        Debug.Log("Strength player: " + player.Strength);
        //Debug.Log("Está activo?"+player.Ready);//Esta línea dará error porque Ready es un campo protegido
        //Se llama a la REDEFINICIÓN del método ShowMessage() (método virtual)
        player.ShowMessage();

        enemy = new Enemy(nameEnemy, healthEnemy, speedEnemy, levelEnemy);

        //Añadimos el enemigo a la lista para que no se produzca un error posteriormente
        Statistics.enemies.Add(enemy);
        Debug.Log("SHOW MESSAGE DEL ENEMIGO ES EL DE LA CLASE BASE");
        enemy.ShowMessage();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            personaje.Health++;//Hace uso del setter
            Debug.Log("Salud Incrementada: "+personaje.Health);
        }
        //Probamos el uso de TakeDamage
        //Podemos ver los efectos en el inspector
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.TakeDamage(1);
            Debug.Log("Vida del enemigo: " + enemy.Health);
        }

        //Probamos el método Shoot implementado en la clase derivada Enemy
        //Podemos ver los efectos en el inspector
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            enemy.Shoot();
            Debug.Log("Proyectiles disponible: " + enemy.BulletCount);

        }


        
        if (Input.GetKeyDown(KeyCode.L))
        {
            personaje.Level += 100;//Hace uso del setter
            Debug.Log("Nivel incrementado: " + personaje.Level);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Si el número de enemigos creados hasta el momento no alcanza el número máximo de enemigos
            if (Enemy.nEnemies <= Statistics.MaxEnemies)
            {
                Statistics.enemies.Add(new Enemy("Enemigo" + Enemy.nEnemies, healthEnemyG, speedEnemyG, levelEnemyG));
                Debug.Log(Statistics.enemies[Enemy.nEnemies - 1].NamePlayer);

                 //Probamos el acceso a una variable global den GameManager
                GameManager.Instance.GlobalCounter++;
                Debug.Log("Contador en el Gamemanager: "+GameManager.Instance.GlobalCounter);
            }
            else
            {
                Debug.Log("No se pueden crear más enemigos");
            }
        }

         if (Input.GetKeyDown(KeyCode.M))
         {
             player.Attack();//--> Lógica de ataque de Player
         }
         if (Input.GetKeyDown(KeyCode.N))
         {
             enemy.Attack();//--> Lógica de ataque de Enemigo
         }


    }
}


