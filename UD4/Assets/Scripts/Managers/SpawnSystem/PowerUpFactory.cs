using Unity.VisualScripting;
using UnityEngine;

public static class PowerUpFactory
{
        public static ObjectPoolBehaviour CreateRandomPowerup()
    {
        PowerUpType randomType =(PowerUpType)System.Enum.GetValues(typeof(PowerUpType))
    .GetValue(Random.Range(0, System.Enum.GetValues(typeof(PowerUpType)).Length));
                

        ObjectPoolBehaviour powerUp = PoolManager.Instance.GetFromPool((PoolObjectType)randomType);

        return powerUp;
    }
}
