using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<AnimatedGeometry> SpawnedObjects { private set; get; }

    [SerializeField] private float orbitalRadius;
    [SerializeField] private AnimatedGeometry objectPrefab;

    private int[] multipliers = new int[] { 1, 2, 5, 10, 25, 50, 100, 250 };

    private int multiplierIndex;

    private void Awake()
    {
        this.SpawnedObjects = new List<AnimatedGeometry>();
    }

    public void OnReset()
    {
        for (int index = 0; index < this.SpawnedObjects.Count; index++)
        {
            Destroy(this.SpawnedObjects[index].gameObject);
        }
        this.SpawnedObjects.Clear();
    }

    public void SetMultiplierIndex(int index)
    {
        this.multiplierIndex = index;
    }

    public void SetMultiplierIndexToMax()
    {
        this.multiplierIndex = this.multipliers.Length - 1;
    }

    public int GetMultiplier()
    {
        return this.multipliers[this.multiplierIndex];
    }

    public int IncrementMultiplier()
    {
        ++this.multiplierIndex;
        if (this.multiplierIndex >= this.multipliers.Length)
        {
            this.multiplierIndex = 0;
        }

        return this.multipliers[this.multiplierIndex];
    }

    public void Spawn()
    {
        this.Spawn(this.multipliers[this.multiplierIndex]);
    }

    public void Spawn(int totalSpawns)
    {
        for (int index = 0; index < totalSpawns; index++)
        {
            AnimatedGeometry newObject = Instantiate(this.objectPrefab);
            newObject.transform.SetParent(base.transform, false);
            this.SpawnedObjects.Add(newObject);

            newObject.MaterialProp = new Material(newObject.MaterialProp);
        }

        int totalSpawnedObjects = this.SpawnedObjects.Count;
        for (int index = 0; index < totalSpawnedObjects; index++)
        {
            this.SpawnedObjects[index].SetAngle(index * 360f / totalSpawnedObjects);
            this.SpawnedObjects[index].SetOrbitalRadius(this.orbitalRadius);
        }
    }
}