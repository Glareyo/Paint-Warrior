using UnityEngine;

public class MeleeEffect : Effect
{
    [SerializeField] AnimationClip clip;
    void Start()
    {
        Destroy(this.gameObject, clip.length);
    }   

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Struck something! Damage: " + damage);
    }

    public override void Init(Vector2 _startPosition, Quaternion _startRotation, ColorSO _colorSO, int _damage, float _range)
    {
        base.Init(_startPosition, _startRotation, _colorSO, _damage, _range);
    }
}
