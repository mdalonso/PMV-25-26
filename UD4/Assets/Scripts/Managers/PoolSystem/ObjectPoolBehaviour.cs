using UnityEngine;

public class ObjectPoolBehaviour : MonoBehaviour,IPoolable
{
    public PoolObjectType Type { get; private set; }

 

    public void Initialize(PoolObjectType type)
    {
        Type = type;
        
    }

    public void Activate()
    {
        
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        
        gameObject.SetActive(false);
    }

    
}
