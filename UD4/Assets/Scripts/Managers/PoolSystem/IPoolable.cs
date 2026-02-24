public interface IPoolable
{
    
    PoolObjectType Type { get; }//Contendrá el tipo de pool según el enum PoolObjectType
    void Activate();
    void Deactivate();
}
