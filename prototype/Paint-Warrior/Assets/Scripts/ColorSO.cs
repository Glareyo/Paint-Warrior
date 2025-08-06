using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "Scriptable Objects/ColorSO")]
public class ColorSO : ScriptableObject
{
    [SerializeField] string colorName;
    [SerializeField] Color color;

    public string Name { get { return colorName; } }
    public Color Color { get { return color; } }
}
