using UnityEngine;

public class PaintBrushAnimController : MonoBehaviour
{
    [SerializeField] Animator paintBrushAnim;

    [Header("Starting animation clips")]
    [SerializeField] AnimationClip idleClip;
    [SerializeField] AnimationClip useClip;

    //Used to override animation clips within an animator
    AnimatorOverrideController paintBrushAnimOverride;

    void Awake()
    {
        paintBrushAnimOverride = new AnimatorOverrideController(paintBrushAnim.runtimeAnimatorController);
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void SetUpAnimator(AnimationClip idle, AnimationClip use)
    {
        paintBrushAnimOverride[idleClip.name] = idle;
        paintBrushAnimOverride[useClip.name] = use;
        paintBrushAnim.runtimeAnimatorController = paintBrushAnimOverride;

        idleClip = idle;
        useClip = use;
    }

    /// <summary>
    /// Play animation and return how long the animation runs.
    /// </summary>
    /// <returns>Returns clip in seconds</returns>
    public float PlayAnimation()
    {
        paintBrushAnim.SetTrigger("UseAbility");
        paintBrushAnim.SetTrigger("UseAbility");
        return useClip.length;
    }
}
