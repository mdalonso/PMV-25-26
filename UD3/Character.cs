using UnityEngine;

public class Character
{
    public string namePlayer;
    private int _health;
    internal int speed;
    protected int _level;

    public Character(string namePlayer, int health, int speed, int level)
    {
        this.namePlayer = namePlayer;
        //_health = health; --> -se ha comentado para hacer uso de la propiedad
        Health = health;//Se recomiendo el uso a través de la propiedad para usar las validaciones
        this.speed = speed;
        Level = level;
    }

    public int Health { //El campo _health requiere propiedades para asegurar su acceso público
        get => _health; 
        //Si únicamente queremos asignar valor
        //set => _health = value;
        //Si además queremos realizar alguna validación
        set
        {
            _health=Mathf.Max(0, value);//Asegura que no tenga un valor negativo.
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
}
