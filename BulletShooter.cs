using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _shotCooldown;
    [SerializeField] private float _speed;

    private bool _isShooting = true;
    
    private void Start() 
    {
        StartCoroutine(nameof(ShootRepeatedly));
    }
    
    private IEnumerator ShootRepeatedly()
    {
        var wait = new WaitForSeconds(_shotCooldown);
        
        while (_isShooting)
        {
            Vector3 currentPosition = transform.position;
            
            Vector3 shotDirection = (_target.position - currentPosition).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, currentPosition + shotDirection, Quaternion.identity);

            bullet.SetVelocity(shotDirection, _speed);

            yield return wait;
        }
    }
}