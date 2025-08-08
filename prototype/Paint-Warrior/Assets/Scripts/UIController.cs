using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image[] dyeHighlightImages; // All images on the UI that represent dyes
    [SerializeField] TMP_Text[] dyeQty; // All TMP that represents number of each dye.
    [SerializeField] Image paintOnBucket; // Represents the quantity of paint in the bucket.
    [SerializeField] TMP_Text paintQty; // Represents the quantity of paint in the bucket.

    void Start()
    {
        //UpdatePaint();
    }
    void OnEnable()
    {
        Player.OnInventoryUpdate += UpdateInventory;
        Player.OnSwapDye += CycleDyeHighlight;
        Bucket.OnChangePaint += UpdatePaint;
    }

    void OnDisable()
    {
        Player.OnInventoryUpdate -= UpdateInventory;
        Player.OnSwapDye -= CycleDyeHighlight;
        Bucket.OnChangePaint -= UpdatePaint;
    }

    /// <summary>
    /// Updates the inventory based on Player's inventory
    /// </summary>
    void UpdateInventory()
    {
        for (int i = 0; i < Player.instance.Inventory.Length; i++)
        {
            dyeQty[i].text = Player.instance.Inventory[i].quantity.ToString();
        }
    }

    /// <summary>
    /// Cycles through each dye, and highlights the one the player has selected.
    /// </summary>
    void CycleDyeHighlight()
    {
        for (int i = 0; i < Player.instance.Inventory.Length; i++)
        {
            dyeHighlightImages[i].color = new Color(0, 0, 0, 0);
            if (i == Player.instance.DyeSelectIndex)
            {
                dyeHighlightImages[i].color = Color.yellow;
            }
        }
    }

    /// <summary>
    /// Updates the paint on the can
    /// </summary>
    void UpdatePaint()
    {
        ColorSO colorSO = Player.instance.Bucket.PaintColor;
        if (colorSO == null)
        {
            paintOnBucket.color = new Color(0,0,0,0);

        }
        else
        {
            paintOnBucket.color = colorSO.Color;
        }
        
        paintQty.text = Player.instance.Bucket.Quantity + " / " + Player.instance.Bucket.MaxQuantity;
    }
}
