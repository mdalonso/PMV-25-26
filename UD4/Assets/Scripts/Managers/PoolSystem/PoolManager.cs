using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }//Singleton

    //Esta lista constituye la "orden de trabajo" donde vamos a definir qué
    //pools se deben de crear indicando su tipo, su prefab asociado y su tamaño.
    //La lista se inicializará desde el inspector, por eso está serializada.
    //Esto crea los pools pero estarán vacíos.
    [SerializeField] private List<ObjectPool> pools;

    //El diccionario almacenará los pools creados y facilitará su acceso mediante su tipo.
    private Dictionary<PoolObjectType, ObjectPool> poolDictionary;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        poolDictionary = new Dictionary<PoolObjectType, ObjectPool>();

        //Para todos los pools definidos en la lista ("orden de trabajo")
        foreach (ObjectPool pool in pools)
        {
            //Se inicaliza el pool metiendo todos los objetos que se necesiten.
            pool.Initialize(transform);
            //Se añade el pool al diccionario para facilitar su gestión.
            poolDictionary.Add(pool.type, pool);
        }
    }

    public ObjectPoolBehaviour GetFromPool(PoolObjectType type)
    {
        //Sacamos un objeto de uno de los pools identificando el pool por su tipo.
        return poolDictionary[type].Get();
    }

    public void ReturnToPool(ObjectPoolBehaviour objeto)
    {
        //Devolvemos el objeto al pool adecuado identificándolo por su tipo
        poolDictionary[objeto.Type].Return(objeto);
    }
}
