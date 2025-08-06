using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] string ingredientName;

    [Header("All Possible Colors")]
    [SerializeField] ColorSO[] Colors;


    Sprite sprite;

    public string Name { get { return ingredientName; } }
    public ColorSO ColorSO { get; private set; }
    public Sprite Sprite { get { return sprite; } }

    void Start()
    {
        RandomlyChooseColor();
    }

    /// <summary>
    /// Randomly choose a color
    /// </summary>
    void RandomlyChooseColor()
    {
        int index = Random.Range(0, Colors.Length);
        ColorSO = Colors[index];

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
        sr.color = new Color(ColorSO.Color.r, ColorSO.Color.g, ColorSO.Color.b, 1);
    }
}
