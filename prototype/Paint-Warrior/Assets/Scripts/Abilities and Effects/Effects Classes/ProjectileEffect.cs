using UnityEngine;

public class ProjectileEffect : Effect
{
    [SerializeField] float speed = 10;

    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Struck something! Damage: " + damage);
        Destroy(this.gameObject);
    }

    public override void Init(Vector2 _startPosition, Quaternion _startRotation, ColorSO _colorSO, int _damage, float _range)
    {
        base.Init(_startPosition, _startRotation, _colorSO, _damage, _range);
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void RunEffect()
    {
        //rb.AddForce(Vector2.right * speed * Time.deltaTime);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
