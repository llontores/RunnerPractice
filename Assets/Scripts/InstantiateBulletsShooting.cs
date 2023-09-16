using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour
{

    [SerializeField] private float _force;
    [SerializeField] private Transform _prefab;
    [SerializeField] private float _bulletsDelay;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        bool isWork = true;
        Rigidbody bulletRigidBody;
        WaitForSeconds delay = new WaitForSeconds(_bulletsDelay);

        while (isWork == true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Transform newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            bulletRigidBody = newBullet.GetComponent<Rigidbody>();
            bulletRigidBody.transform.up = direction;
            bulletRigidBody.velocity = direction * _force;

            yield return delay;
        }
    }
}