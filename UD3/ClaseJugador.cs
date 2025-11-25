using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseJugador : MonoBehaviour
{
    BasicPlayer player;
   

    // Start is called before the first frame update
    void Start()
    {
        player = new BasicPlayer("Mi personaje", 10);

        Debug.Log("Nombre de mi personaje: " + player.name);
    }

    void IncreaseHealth()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            player.health++;
            Debug.Log("Vida de  mi personaje: "+player.health);
        }
    }

  

    // Update is called once per frame
    void Update()
    {
       IncreaseHealth();

    }
}
