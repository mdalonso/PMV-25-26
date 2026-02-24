using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ObjectPool
{
    public PoolObjectType type;
    public ObjectPoolBehaviour prefab;
    public int initialSize = 10;

    private Queue<ObjectPoolBehaviour> poolQueue = new Queue<ObjectPoolBehaviour>();
    private Transform parent;

    //En lugar de un constructor, y teniendo en cuenta que la inicialización no consiste en una
    //mera asignación de valores a los campos de la clase, creamos el método Initialize en el cual
    //determinamos dónde se va a organizar el pool en la jerarquía (parent) y creamos todas las instancias
    //del prefab según el tamaño de pool definido.
    public void Initialize(Transform parentTransform)
    {
        parent = parentTransform;

        for (int i = 0; i < initialSize; i++)
        {
            CreateInstance();
        }
    }
    //La creación de cada objeto supone 
    //- instanciar el prefab.
    //- Desactivarlo ya que inicialmente no está en escena
    //- Meterlo en la cola
  
    private ObjectPoolBehaviour CreateInstance()
    {
        ObjectPoolBehaviour objeto = Object.Instantiate(prefab, parent);
        objeto.gameObject.SetActive(false);
        poolQueue.Enqueue(objeto);
        return objeto;
    }

    //Get permite extraer objetos del pool
    public ObjectPoolBehaviour Get()
    {
        //Si ya no queda ningún objeto en el pool lo creamos
        //Si quisiéramos limitar el tamaño del pool de forma real, esto no lo hacemos
        if (poolQueue.Count == 0)
        {
            CreateInstance();
        }
        //Si aún quedan objetos en el pool, lo extraemos, lo activamos y lo devolvemos.
        ObjectPoolBehaviour objeto = poolQueue.Dequeue();
        objeto.Activate();
        return objeto;
    }
    //Una vez que el objeto ya no se necesita lo devolvemos al pool y esto supone
    //su desactivación y volver a encolarlo.
    public void Return(ObjectPoolBehaviour objeto)
    {
        objeto.Deactivate();
        poolQueue.Enqueue(objeto);
    }
}
