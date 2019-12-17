using UnityEngine;
using UnityEngine.UI;

public class AnimatedGeometry : MonoBehaviour
{
    [SerializeField] private Image imageRef;
    [SerializeField] private RectTransform rectTransformRef;

    public Material MaterialProp
    {
        get => this.imageRef.material;
        set => this.imageRef.material = value;
    }

    public void SetAngle(float angle)
    {
        Vector3 newAngle = base.transform.eulerAngles;
        newAngle.z = angle;
        base.transform.eulerAngles = newAngle;
    }

    public void SetOrbitalRadius(float radius)
    {
        Vector3 newPosition = this.rectTransformRef.anchoredPosition;
        newPosition.y = radius;
        this.rectTransformRef.anchoredPosition = newPosition;
    }
}
