using System;
using TMPro;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] SpriteRenderer paintSprite;
    [Header("Stats")]
    [SerializeField] int BaseDamage; // Base damage  that bucket reverts to.
    [SerializeField] float BaseSpeed; // Base speed the bucket can use for certain actions (mix, use, etc...)
    [SerializeField] int BaseMaxQuantity; // Starting max quantity of paint the bucket can hold


    ColorSO paintColor; // What color paint the bucket has.
    int quantity; // Current Quantity of paint the bucket has
    int modifiedDamage; // BaseDamage + Modification Stats
    float modifiedSpeed; // BaseSpeed + Modification Stats
    int modifiedMaxQuantity; // BaseMaxQuantity + Modification Stats.

    public int MaxQuantity { get { return modifiedMaxQuantity; } }
    public int Quantity { get { return quantity; } }

    Color NO_PAINT = new Color(0, 0, 0, 0);

    public static Action OnChangePaint;

    // Implement Modification

    public ColorSO PaintColor { get { return paintColor; } }

    void Start()
    {
        paintColor = null;
        ChangePaintSprite(NO_PAINT);
        modifiedDamage = BaseDamage;
        modifiedSpeed = BaseSpeed;
        modifiedMaxQuantity = BaseMaxQuantity;
    }

    void Update()
    {

    }

    /// <summary>
    /// Checks to see if the bucket has enough paint
    /// </summary>
    /// <param name="qty"></param>
    /// <returns></returns>
    public bool HasEnoughPaint(int qty)
    {
        if (qty <= quantity)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks to see if the bucket can mix paint into it.
    /// </summary>
    /// <param name="colorSO"></param>
    /// <returns></returns>
    public bool CanMixPaint(ColorSO colorSO)
    {
        if (paintColor == null)
        { // No Paint Inside
            return true;
        }
        if (paintColor == colorSO && quantity < modifiedMaxQuantity)
        { // Paint is the same and it isn't full
            return true;
        }
        return false;
    }


    /// <summary>
    /// Create paint with a certain color and qty.
    /// </summary>
    /// <param name="colorSO"></param>
    /// <param name="mixQuantity"></param>
    public void MixPaint(ColorSO colorSO, int mixQuantity)
    {
        paintColor = colorSO;
        quantity += mixQuantity;
        if (quantity > modifiedMaxQuantity)
        {
            quantity = modifiedMaxQuantity;
        }
        ChangePaintSprite(colorSO.Color);
    }

    /// <summary>
    /// Change the color on the paint can.
    /// </summary>
    /// <param name="color"></param>
    void ChangePaintSprite(Color color)
    {
        paintSprite.color = color;
        OnChangePaint?.Invoke();
    }

    /// <summary>
    /// Dump the contents of the bucket
    /// </summary>
    public void Dump()
    {
        quantity = 0;
        paintColor = null;
        ChangePaintSprite(NO_PAINT);
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
            paintColor = null;
            ChangePaintSprite(NO_PAINT);
        }

        OnChangePaint?.Invoke();
    }


    /// <summary>
    /// Replace the modification and update all stats.t
    /// </summary>
    // public void ApplyModifications(Modification mod)
    // {

    // }
}
