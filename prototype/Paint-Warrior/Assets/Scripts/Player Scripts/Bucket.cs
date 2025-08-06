using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject paintGameObject;
    [Header("Stats")]
    [SerializeField] int BaseDamage; // Base damage  that bucket reverts to.
    [SerializeField] float BaseSpeed; // Base speed the bucket can use for certain actions (mix, use, etc...)
    [SerializeField] int BaseMaxQuantity; // Starting max quantity of paint the bucket can hold
    [SerializeField] ColorSO startingPaintColor; // What color the player starts with at the moment.

    ColorSO paintColor; // What color paint the bucket has.
    int quantity; // Current Quantity of paint the bucket has
    int modifiedDamage; // BaseDamage + Modification Stats
    float modifiedSpeed; // BaseSpeed + Modification Stats
    int modifiedMaxQuantity; // BaseMaxQuantity + Modification Stats.
    SpriteRenderer paintSpriteRenderer;

    // Implement Modification

    public ColorSO PaintColor { get { return paintColor; } }

    void Start()
    {
        paintSpriteRenderer = paintGameObject.GetComponent<SpriteRenderer>();
        paintColor = startingPaintColor;
        ToggleOnPaintSprite();
    }

    void Update()
    {

    }

    public void MixPaint(ColorSO color, int mixQuantity)
    {
        paintColor = color;
        quantity = mixQuantity;
        if (quantity > modifiedMaxQuantity)
        {
            quantity = modifiedMaxQuantity;
        }
        if (!paintGameObject.activeSelf)
        {
            ToggleOnPaintSprite();
        }
    }

    /// <summary>
    /// Dump the contents of the bucket
    /// </summary>
    public void Dump()
    {
        quantity = 0;
        paintColor = null;
        ToggleOffPaintSprite();
    }



    /// <summary>
    /// Returns paint being used and reduces current quantity.
    /// </summary>
    /// <param name="useQuantity"></param>
    public void UsePaint(int useQuantity)
    {
        quantity -= useQuantity;
        if (quantity <= 0)
        {
            quantity = 0;
            ToggleOffPaintSprite();
        }
    }

    void ToggleOffPaintSprite()
    {
        paintGameObject.SetActive(false);
    }
    void ToggleOnPaintSprite()
    {
        paintGameObject.SetActive(true);
        paintSpriteRenderer.color = new Color(paintColor.Color.r, paintColor.Color.g, paintColor.Color.b, 1);
    }

    /// <summary>
    /// Replace the modification and update all stats.t
    /// </summary>
    // public void ApplyModifications(Modification mod)
    // {

    // }
}
