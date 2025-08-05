using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] int health;
    [SerializeField] float moveSpeed;



    //Private Variables
    private PlayerInputController playerInputController;
    private Bucket bucket;
    private Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();

    //Actions
    public static Action OnDead;


    void Start()
    {
        //bucket = GetComponentInChildren<Bucket>();
        playerInputController = GetComponent<PlayerInputController>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        MovePlayer();   
    }

    /// <summary>
    /// Player chooses an ability to use
    /// </summary>
    void SelectAbility()
    {
        
    }
    /// <summary>
    /// Uses the ability the player has selected.
    /// </summary>
    void UseAbility()
    {

    }

    /// <summary>
    /// Adds to the inventory or score.
    /// </summary>
    /// <param name="item">GameObject that is marked as an item</param>
    void PickupItem(GameObject item)
    {

    }

    /// <summary>
    /// Adds ingredient to inventory
    /// </summary>
    /// <param name="ingredient"></param>
    /// <param name="quantity"></param>
    void AddToInventory(Ingredient ingredient, int quantity)
    {

    }

    /// <summary>
    /// Opens inventory or ingredients for the player to mix paint
    /// </summary>
    void MixItems()
    {

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
