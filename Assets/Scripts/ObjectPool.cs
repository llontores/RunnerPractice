using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _contatiner;
    [SerializeField] private int _amount;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _amount; i++)
        {
            GameObject spawned = Instantiate(prefab, _contatiner.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }

    //public List<GameObject> GetObjects()
    //{
    //    return _pool;
    //}
}
