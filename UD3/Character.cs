using UnityEngine;

public class Character
{
    //CÓDIGO TRADICIONAL*************************
    //Podemos sustituir los campos por propiedades auto-implementadas para modernizar el código.
    //Esta sería la forma tradicional de declarar campos: declaración del campo + propiedad (en el caso de private o protected con necesidad
    //de acceso público)

    //public string namePlayer;
    private int _health;
    //internal int speed;
    protected int _level;

    //C# moderno ***********************************
    //Se sustituye la declaración de campos por propiedades autoimplementadas salvo:
    //- Cuando estamos declarando campos privados de uso interno de la clase (no requieren ser accedidos desde el exterior en ningún caso)
    //- Se requiere implementar lógica interna en los getters/setters
    public string NamePlayer { get; set; }
    internal int Speed { get; set; }
    //Definimos un campo protected que sólo será utilizado dentro de la clase y sus derivadas, pero no de forma pública
    protected bool Ready { get; set; }
    
    
    
    public Character(string namePlayer, int health, int speed, int level,bool ready=true)//Valor por defecto de un parámetro
    {
        //Uso de las propiedades autoimplementadas en el constructor.
        NamePlayer = namePlayer;
        //_health = health; --> -se ha comentado para hacer uso de la propiedad
        Health = health;//Se recomiendo el uso a través de la propiedad para usar las validaciones
        Speed = speed;
        Level = level;
        Ready = ready;//Si no se recibe nada como parámetro, Ready tomará valor true por defecto
    }

    public int Health { //El campo _health requiere propiedades para asegurar su acceso público
        get => _health; 
        //Si únicamente queremos asignar valor
        //set => _health = value;
        //Si además queremos realizar alguna validación
        set
        {
            _health=Mathf.Max(0, value);//Asegura que no tenga un valor negativo.
            if (_health <= 0) Die();
        }
    }


    public int Level
    {
        get { return _level; }//Es equivalente a =>_level;
        set
        {
            _level = Mathf.Max(0, value);
        }
    }

    //Método TakeDamage: resta vida al enemigo por haber recibido un daño.
    //Hace uso de la propiedad para acceder al campo Health.
    public void TakeDamage(int damage)
    {
        Health -= damage;       
    }

    //El método Die sólo es accesible desde el interior de la clase. Se llama en el setter de health
    private void Die()
    {
        Debug.Log(NamePlayer + " has died.");

    }

    //Se define un método virtual que se reescribirá en las clases derivadas
    public virtual void ShowMessage()
    {
        Debug.Log("**********************INFORME DE PERSONAJE BÁSICO*****************************");

    }
}

