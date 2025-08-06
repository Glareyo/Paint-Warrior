using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    [Header("Name and Slot Number")]
    [SerializeField] string abilityName; // Name of the ability
    [Tooltip("What assigned number the ability will have on the UI")]
    [SerializeField] int slotNum; // Slot number, for the player ability selection

    [Header("Animation Clips")]
    [SerializeField] AnimationClip idleAnim; // Idle animation clip
    [SerializeField] AnimationClip useAnim; // Use animation clip

    [Header("Effect Prefab")]
    [SerializeField] GameObject effectPrefab; // Effect prefab

    [Header("Stat Modifiers")]
    [SerializeField] int damageModifier; // Damage modifier of the ability
    [SerializeField] float rangeModifier; // Modifier for the range.
    [SerializeField] int cost; // How much paint is needed to use the ability
    [SerializeField] bool createEffectImmediately; //Determines if the effect should be created straight away.

    

    // Properties
    public string Name { get { return name; } }
    public int SlotNum { get { return slotNum; } }
    public AnimationClip IdleAnim { get { return idleAnim; } }
    public AnimationClip UseAnim { get { return useAnim; } }
    public GameObject EffectPrefab { get { return effectPrefab; } }
    public int DamageModifier { get { return damageModifier; } }
    public float RangeModifier { get { return rangeModifier; } }
    public int Cost { get { return cost; } }
    public bool CreateEffectImmediately { get { return createEffectImmediately; } }
}
