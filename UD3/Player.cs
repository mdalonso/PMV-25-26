using UnityEngine;

public class Player:Character,IAttack
{

    public int Strength {  get; set; }

    //Cuando el constructor de la clase base tiene parámetros de entrada es necesario hacer referencia 
    //a él en el constructor de la clase derivada.
    public Player(string namePlayer, int health,int speed, int level, int strength,bool ready=true):base(namePlayer,health,speed,level,ready)
    {
        Strength = strength;
    }

    //Sobreescritura del método virtual de la clase base ShowMessage
    //Si no se sobreescribe, hará uso del método de la clase base.
    public override void ShowMessage()
    {
        Debug.Log("++++++++++++++++++ Informe de Player +++++++++++++++++++++++++++");
        Debug.Log("Mi nombre es: " + NamePlayer);
        //El campo health está definido como private, por tanto no podemos acceder directamente a este campo
        //Debug.Log(this._health); //Esta línea dará un error porque health está definida como private en la clase base
        Debug.Log("Mi vida es: " + Health);
        Debug.Log("Mi velocidad es: " + Speed);
        //Como _level es PROTECTED sí es acceible desde la clase derivada
        Debug.Log("Mi puntuación es: " + _level);//Level es un campo protegido al que se accede sin problemas desde la clase derivada.
        Debug.Log("Mi fuerza es: " + Strength);
        //Operador ternario
        Debug.Log(Ready?"Estoy preparado":"Aun NO estoy preparado");
        Debug.Log("++++++++++++++++++ FIN DE INFORME DE PLAYER +++++++++++++++++++++++++++");


    }

    public void Attack()
    {
        Debug.Log("Lógica de ataque del player");
    }

}

