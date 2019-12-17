using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GeometriesDisplay : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextMeshProUGUI totalGeometriesDisplayText;

    private void OnValidate()
    {
        if (this.totalGeometriesDisplayText == null)
        {
            this.totalGeometriesDisplayText = base.GetComponent<TextMeshProUGUI>();
        }
    }

    public void OnReset()
    {
        this.totalGeometriesDisplayText.text = "0";
    }

    public void OnGeometrySpawn()
    {
        this.totalGeometriesDisplayText.text = this.spawner.SpawnedObjects.Count.ToString();
    }
}
