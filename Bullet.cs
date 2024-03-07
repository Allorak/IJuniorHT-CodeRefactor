using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 shotDirection, float velocity)
    {
        _rigidbody.transform.up = shotDirection;
        _rigidbody.velocity = _rigidbody.transform.up * velocity;
    }
}