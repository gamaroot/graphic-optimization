using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GeometriesMultiplierDisplay : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextMeshProUGUI multiplierDisplayText;

    [Range(0, 7)]
    [SerializeField] private int defaultMultiplierIndex = 0;

    private void OnValidate()
    {
        if (this.multiplierDisplayText == null)
        {
            this.multiplierDisplayText = base.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Awake()
    {
        this.UpdateDefaultMultiplier();
    }

    private void UpdateDefaultMultiplier()
    {
        this.spawner.SetMultiplierIndex(this.defaultMultiplierIndex);
        this.multiplierDisplayText.text = "x" + this.spawner.GetMultiplier();
    }

    public void IncrementMultiplier()
    {
        int multiplier = this.spawner.IncrementMultiplier();

        this.multiplierDisplayText.text = "x" + multiplier;
    }
}
