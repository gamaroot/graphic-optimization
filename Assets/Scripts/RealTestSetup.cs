using UnityEngine;

public class RealTestSetup : MonoBehaviour
{
    [SerializeField] private Spawner[] spawners;
    [SerializeField] private GeometriesDisplay[] GeometriesDisplays;
    [SerializeField] private TotalGeometriesDisplay totalGeometriesDisplay;
    [SerializeField] private int totalSpawns = 130;

    public void ApplyRealTest()
    {
        for (int index = 0; index < this.spawners.Length; index++)
        {
            Spawner spawner = this.spawners[index];

            spawner.OnReset();
            spawner.Spawn(this.totalSpawns);
        }

        for (int index = 0; index < this.spawners.Length; index++)
        {
            GeometriesDisplay geometriesDisplay = this.GeometriesDisplays[index];

            geometriesDisplay.OnGeometrySpawn();
        }

        this.totalGeometriesDisplay.OnGeometrySpawn();
    }
}
