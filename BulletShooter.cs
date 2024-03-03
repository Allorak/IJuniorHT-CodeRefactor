using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
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
            var currentPosition = transform.position;
            
            var shotDirection = (_target.position - currentPosition).normalized;
            var bullet = Instantiate(_bulletPrefab, currentPosition + shotDirection, Quaternion.identity);

            var bulletRigidBody = bullet.GetComponent<Rigidbody>();
            bulletRigidBody.transform.up = shotDirection;
            bulletRigidBody.velocity = shotDirection * _speed;

            yield return wait;
        }
    }
}