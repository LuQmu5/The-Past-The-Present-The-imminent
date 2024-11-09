using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _itemPrefab;
    private List<T> _pool;

    protected void InitPool(T itemPrefab)
    {
        _pool = new List<T>();
        _itemPrefab = itemPrefab;
    }

    public T GetItem()
    {
        T item = _pool.Find(i => i.gameObject.activeSelf == false);

        if (item == null)
        {
            item = Object.Instantiate(_itemPrefab);
            _pool.Add(item);
        }

        return item;
    }
}