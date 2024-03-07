using System.Collections;
using UnityEngine;

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
        WaitForSeconds wait = new WaitForSeconds(_shotCooldown);
        
        while (_isShooting)
        {
            Vector3 currentPosition = transform.position;
            
            Vector3 shotDirection = (_target.position - currentPosition).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, currentPosition + shotDirection, Quaternion.identity);

            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.transform.up = shotDirection;
            bulletRigidbody.velocity = shotDirection * _speed;

            yield return wait;
        }
    }
}