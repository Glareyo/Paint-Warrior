using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{

    [Tooltip("What abilities the player will start with.")]
    [SerializeField] AbilitySO[] startingAbilities;
    [SerializeField] float offset;
    [Tooltip("Where the effect will be created at.")]
    [SerializeField] Transform effectPoint;

    public Dictionary<int, AbilitySO> abilities; //What abilities the player has. int > abilitySO.slotNumber, abilitySO > abilitySO
    AbilitySO currentAbility; //Current Ability Selected

    // Stats retrieved from Player.cs
    int damage;
    float speed;
    float range;

    PaintBrushAnimController animController;

    void Awake()
    {
        abilities = new Dictionary<int, AbilitySO>();

        //Add starting abilities to abilities
        foreach (AbilitySO a in startingAbilities)
        {
            AddAbility(a);
        }

        animController = GetComponent<PaintBrushAnimController>();
        currentAbility = startingAbilities[0];
    }
    void Start()
    {
        //Set up paint brush animation controller
        SetAnimations();
    }



    void Update()
    {
        RotatePaintBrush();
    }

    /// <summary>
    /// Sets all the stats for faster processing
    /// </summary>
    /// <param name="_dmg"></param>
    /// <param name="_spd"></param>
    /// <param name="_range"></param>
    public void SetStats(int _dmg, float _spd, float _range)
    {
        damage = _dmg;
        speed = _spd;
        range = _range;
    }

    /// <summary>
    /// Changes the CurrentAbilitySO based on inputted number
    /// </summary>
    /// <param name="number">Player inputted Number</param>
    public void SelectAbility(int number)
    {
        //Check dictionary for key.
        //If Key doesn't exist, exit.
        //Else set currentAbilitySO to abilitySO from dictionary.

        if (abilities.ContainsKey(number))
        {
            currentAbility = abilities[number];
        }
    }

    /// <summary>
    /// Adds an ability to the dictionary.t
    /// </summary>
    /// <param name="ability"></param>
    public void AddAbility(AbilitySO ability)
    {
        if (!abilities.ContainsValue(ability))
        {
            abilities.Add(ability.SlotNum, ability);
        }
    }

    /// <summary>
    /// Uses the ability currently selected.
    /// </summary>
    public void UseAbility()
    {
        
        if (currentAbility.CreateEffectImmediately)
        {
            //Create the effect straight away.
            //Usually for melee animations
            animController.PlayAnimation();
            CreateEffect();
        }
        else
        {
            //Start coroutine based on animation.
            //After animation is done, then instantiate effect.
            Invoke("CreateEffect", animController.PlayAnimation());
        }
    }

    /// <summary>
    /// Creates the ability effect after paintbrush animation
    /// </summary>
    void CreateEffect()
    {
        Effect effect = Instantiate(currentAbility.EffectPrefab, this.transform.position, Quaternion.identity).GetComponent<Effect>();
        effect.Init(effectPoint.position, effectPoint.rotation);
    }

    void RotatePaintBrush()
    {
        //Credit: Game Dev Rocket
        //6 STEPS to make a TOP DOWN SHOOTER Game | Unity 2023 Tutorial
        //https://www.bing.com/videos/riverview/relatedvideo?q=Unity+top-down+shooter&mid=014844B0AF3EFB624ECB014844B0AF3EFB624ECB&FORM=VIRE

        //Get distance of weapon position and mouse position.
        Vector2 displacement = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Determine angle from displacement.
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        //Rotate the weapon in the target direction. Offset in order to make it look correct.
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle - offset);
    }

    /// <summary>
    /// Set up animations in the anim controller
    /// </summary>
    public void SetAnimations()
    {
        animController.SetUpAnimator(currentAbility.IdleAnim, currentAbility.UseAnim);
    }
}
