using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour
{

    [SerializeField] private float _force;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _bulletsDelay;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shooting());
    }
    private IEnumerator Shooting()
    {
        bool isWork = true;
        WaitForSeconds delay = new WaitForSeconds(_bulletsDelay);

        while (isWork == true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _force;

            yield return delay;
        }
    }
}