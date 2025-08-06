using UnityEngine;


// Must have classes derived from it.
public abstract class Effect : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public virtual void Init(Vector2 _startPosition, Quaternion _startRotation)
    {
        this.transform.position = _startPosition;
        this.transform.rotation = _startRotation;
    }
}
