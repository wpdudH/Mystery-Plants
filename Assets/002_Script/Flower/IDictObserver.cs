using UnityEngine;

public interface IDictObserver
{
    void OnFlowerDiscovered(EnvironmentType environment, FlowerData flower);
}
