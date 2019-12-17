using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TotalGeometriesDisplay : MonoBehaviour
{
    [SerializeField] private Spawner[] spawners;
    [SerializeField] private TextMeshProUGUI totalGeometriesDisplayText;

    private const string LABEL = "Total: ";

    private void OnValidate()
    {
        if (this.totalGeometriesDisplayText == null)
        {
            this.totalGeometriesDisplayText = base.GetComponent<TextMeshProUGUI>();
        }
    }

    public void OnReset()
    {
        this.totalGeometriesDisplayText.text = LABEL + "0";
    }

    public void OnGeometrySpawn()
    {
        int count = 0;
        for (int index = 0; index < this.spawners.Length; index++)
        {
            count += this.spawners[index].SpawnedObjects.Count;
        }
        
        this.totalGeometriesDisplayText.text = LABEL + count.ToString();
    }
}
