using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public struct InventorySlot
{
    public Ingredient ingredient;
    public int quantity;
    public string description;
}

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] int health;
    [SerializeField] float moveSpeed;

    [Header("GameObject Components")]
    [SerializeField] PaintBrush paintBrush;
    [SerializeField] Bucket bucket;
    public Bucket Bucket { get { return this.bucket; } }

    [Header("Inventory")]
    [SerializeField] Ingredient[] ingredientSlots;

    //Inventory System
    InventorySlot[] inventory;
    public InventorySlot[] Inventory { get { return inventory; } }

    public static Player instance; // Singleton => There will only be 1 player.

    //Private Variables
    private PlayerInputController playerInputController;
    private int dyeSelectIndex = 0;
    private int abilitySelectIndex = 1;

    public int DyeSelectIndex { get { return dyeSelectIndex; } }

    //Actions
    public static Action OnDead;
    public static Action OnInventoryUpdate;
    public static Action OnSwapDye;
    public static Action OnAbilitySwap;

    //Colliding Objects
    // Used to detect if a consumable is within range. Help ensure it doesn't fire over and over again.
    GameObject ConsumableObject;


    void Start()
    {
        if (instance == null || this.gameObject != instance)
        {
            instance = this;
        }
        //bucket = GetComponentInChildren<Bucket>();
        playerInputController = GetComponent<PlayerInputController>();
        if (paintBrush == null)
        {
            paintBrush = GetComponentInChildren<PaintBrush>();
        }
        if (bucket == null)
        {
            bucket = GetComponentInChildren<Bucket>();
        }

        inventory = new InventorySlot[ingredientSlots.Length];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i].ingredient = ingredientSlots[i];
            inventory[i].quantity = 0;
            inventory[i].description = "";
        }
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        MovePlayer();
        UseAbility();

        if (playerInputController.isPickupPressed)
        {
            PickupItem(ConsumableObject);
        }
        if (playerInputController.isSwapDyePressed)
        {
            ChangeDyeIndex();
        }
        if (playerInputController.isMixPaintPressed)
        {
            MakePaint();
        }
        if (playerInputController.isRightMouseClicked)
        {
            SelectAbility();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ingredient"))
        {
            if (ConsumableObject == other.gameObject)
            {
                return;
            }
            ConsumableObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (ConsumableObject == other.gameObject)
        {
            ConsumableObject = null;
        }
    }

    /// <summary>
    /// Player chooses an ability to use
    /// </summary>
    void SelectAbility()
    {
        abilitySelectIndex++;
        if (abilitySelectIndex > paintBrush.abilitySlots)
        {
            abilitySelectIndex = 1;
        }

        paintBrush.SelectAbility(abilitySelectIndex);

        OnAbilitySwap?.Invoke();
        playerInputController.OnRightClickToggle(false);
    }
    /// <summary>
    /// Uses the ability the player has selected.
    /// </summary>
    void UseAbility()
    {
        if (playerInputController.isLeftMouseClicked)
        {
            if (bucket.HasEnoughPaint(paintBrush.ReqQty))
            {
                paintBrush.UseAbility();
                bucket.UsePaint(paintBrush.ReqQty);
                OnInventoryUpdate?.Invoke();
            }
            playerInputController.OnLeftClickToggle(false);
        }
    }

    /// <summary>
    /// Adds to the inventory or score.
    /// </summary>
    /// <param name="item">GameObject that is marked as an item</param>(
    void PickupItem(GameObject item)
    {
        playerInputController.OnPickupToggle(false);
        if (item == null) return;

        if (item.CompareTag("Ingredient"))
        {
            AddToInventory(item.GetComponent<Ingredient>(), 1);
        }

        Destroy(item.gameObject);
    }

    /// <summary>
    /// Adds ingredient to inventory
    /// </summary>
    /// <param name="ingredient"></param>
    /// <param name="quantity"></param>
    void AddToInventory(Ingredient ingredient, int quantity)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].ingredient.Name == ingredient.Name)
            {
                inventory[i].quantity += quantity;
            }
        }

        OnInventoryUpdate?.Invoke();
    }

    /// <summary>
    /// Changes the dyeSelectIndex to change to another dye
    /// </summary>
    void ChangeDyeIndex()
    {
        dyeSelectIndex++;
        if (dyeSelectIndex >= inventory.Length)
        {
            dyeSelectIndex = 0;
        }
        playerInputController.OnSwapDyeToggle(false);
        OnSwapDye?.Invoke();
    }

    /// <summary>
    /// Opens inventory or ingredients for the player to mix paint
    /// </summary>
    void MakePaint()
    {
        ColorSO selectedIngredient = inventory[dyeSelectIndex].ingredient.ColorSO;
        if (bucket.CanMixPaint(selectedIngredient))
        {
            if (inventory[dyeSelectIndex].quantity >= 1)
            {
                bucket.MixPaint(selectedIngredient, 1);
                paintBrush.SetColor(selectedIngredient);
                inventory[dyeSelectIndex].quantity--;
            }
        }

        OnInventoryUpdate?.Invoke();

        playerInputController.OnMixPaintToggle(false);
    }

    /// <summary>
    /// Empties the contents of the bucket. => Calls Bucket.Dump
    /// </summary>
    void DumpBucket()
    {

    }

    /// <summary>
    /// When the player's health <= 0
    /// </summary>
    void IsDead()
    {

    }

    /// <summary>
    /// Input Controller =? On Player move
    /// </summary>
    void MovePlayer()
    {
        if (playerInputController.MoveDirection == Vector2.zero) return;

        Vector2 moveDirection = playerInputController.MoveDirection;
        transform.position = new Vector2(transform.position.x + moveDirection.x * (moveSpeed * Time.deltaTime),
        transform.position.y + moveDirection.y * (moveSpeed * Time.deltaTime));
    }

}
