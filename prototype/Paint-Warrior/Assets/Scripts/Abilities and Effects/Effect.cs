using UnityEngine;


// Must have classes derived from it.
public abstract class Effect : MonoBehaviour
{
    protected ColorSO colorSO;
    protected int damage;
    protected float range;

    protected void Update()
    {
        RunEffect();
    }

    public virtual void Init(Vector2 _startPosition, Quaternion _startRotation, ColorSO _colorSO, int _damage, float _range)
    {
        this.transform.position = _startPosition;
        this.transform.rotation = _startRotation;
        this.colorSO = _colorSO;
        this.damage = _damage;
        this.range = _range;
        this.GetComponent<SpriteRenderer>().color = colorSO.Color;
    }

    protected virtual void RunEffect()
    {

    }
}
