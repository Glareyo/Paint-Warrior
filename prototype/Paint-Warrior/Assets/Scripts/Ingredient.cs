using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] string ingredientName;

    [Header("All Possible Colors")]
    [SerializeField] ColorSO colorSO;


    Sprite sprite;

    public string Name { get { return ingredientName; } }
    public ColorSO ColorSO { get { return colorSO; } }
    public Sprite Sprite { get { return sprite; } }

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
        sr.color = new Color(ColorSO.Color.r, ColorSO.Color.g, ColorSO.Color.b, 1);
    }
}
