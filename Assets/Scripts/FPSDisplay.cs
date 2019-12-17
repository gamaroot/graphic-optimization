using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;

    private const float FPS_MEASURE_PERIOD = 0.5f;
    private const string FPS_LABEL = " FPS";

    private int fpsAccumulator = 0;
    private float fpsNextPeriod = 0;
    private int currentFps;

    private void OnValidate()
    {
        if (this.display == null)
        {
            this.display = base.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        this.fpsNextPeriod = Time.realtimeSinceStartup + FPS_MEASURE_PERIOD;
    }

    private void Update()
    {
        // measure average frames per second
        this.fpsAccumulator++;
        if (Time.realtimeSinceStartup > this.fpsNextPeriod)
        {
            this.currentFps = (int)(this.fpsAccumulator / FPS_MEASURE_PERIOD);
            this.fpsAccumulator = 0;
            this.fpsNextPeriod += FPS_MEASURE_PERIOD;

            this.display.text = currentFps + FPS_LABEL;
        }
    }

}