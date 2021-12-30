using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> : Singleton<ObjectPool<T>> where T : MonoBehaviour
{
    [SerializeField] T originManagedObj;
    private List<T> pool = new List<T>();
    Transform trnDisable;

    protected override void Awake()
    {
        var obj = new GameObject("Disable");
        pool.Find((T x) => x.tag == "dasd");
        obj.transform.SetParent(transform);
        trnDisable = obj.transform;
    }
    protected virtual void Start()
    {
    }

    public T GetObj()
    {
        T @return = null;
        if (pool.Count > 0)
        {
            @return = pool.FirstOrDefault();
            pool.RemoveAt(0);
            @return.gameObject.SetActive(true);
        }
        else
        {
            @return = Instantiate(originManagedObj);
        }

        return @return;
    }

    public T GetObj(Vector3 pos, Quaternion rot)
    {
        var @return = GetObj();
        @return.transform.position = pos;
        @return.transform.rotation = rot;
        @return.transform.SetParent(null);
        return @return;
    }
    public T GetObj(Vector3 pos, Quaternion rot, Transform parents, bool WorldPositionStays = true)
    {
        var @return = GetObj();
        @return.transform.position = pos;
        @return.transform.rotation = rot;
        @return.transform.SetParent(parents, WorldPositionStays);
        return @return;
    }
    public void ReturnObj(T obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(trnDisable);
        obj.gameObject.SetActive(false);
        pool.Add(obj);
    }

}
