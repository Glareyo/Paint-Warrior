using UnityEngine;

public class MeleeEffect : Effect
{
    [SerializeField] AnimationClip clip;
    void Start()
    {
        Destroy(this.gameObject, clip.length);
    }

    void Update()
    {

    }

    public override void Init(Vector2 _startPosition, Quaternion _startRotation)
    {
        base.Init(_startPosition, _startRotation);
    }
}
