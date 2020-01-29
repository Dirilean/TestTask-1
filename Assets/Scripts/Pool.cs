using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public PoolObjectType[] poolingObjects;

    private void Awake()
    {
        if (instance!=null) Destroy(instance.gameObject);
        instance = this;
    }

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        for (int i = 0; i < poolingObjects.Length; i++)
        {
            for (int t = 0; t < poolingObjects[i].count; t++)
            {
                AddNewPoolObject(poolingObjects[i]).ReturnToPool();
            }
        }
    }

    public PoolObject GetObject(string name, Vector3 position, Quaternion rotation)
    {
        //ищем нужный тип пула с объектами
        PoolObjectType curTypePool = (poolingObjects.FirstOrDefault(x => x.name == name));
        if (curTypePool==null) Debug.LogError(name+" type of pool is not exist");

        //Ищем невключенный элемент
        PoolObject objOfPool = curTypePool.listPoolObjects.FirstOrDefault(x => (x.gameObject.activeInHierarchy == false));
        //Если существующего нет, то создаем новый
        objOfPool=objOfPool?? AddNewPoolObject(curTypePool);

        objOfPool.transform.position = position;
        objOfPool.transform.rotation = rotation;
        objOfPool.gameObject.SetActive(true);

        return objOfPool;
    }
    public PoolObject GetObject(string name,Vector3 position)
    {
        return GetObject(name, position, Quaternion.identity);
    }
    public PoolObject GetObject(string name)
    {
        return GetObject(name, Vector3.zero, Quaternion.identity);
    }

    private PoolObject AddNewPoolObject(PoolObjectType poolTtype)
    {
        PoolObject newPoolingObj = Instantiate(poolTtype.prefab,transform).AddComponent<PoolObject>();
        poolTtype.listPoolObjects.Add(newPoolingObj);
        return newPoolingObj;
    }

    public void ReturnAllToPool()
    {
        for (int i = 0; i < poolingObjects.Length; i++)
        {
            for (int t = 0; t <poolingObjects[i].listPoolObjects.Count; t++)
            {
                if (poolingObjects[i].listPoolObjects[t].gameObject.activeInHierarchy)
                poolingObjects[i].listPoolObjects[t].ReturnToPool();
            }
        }
    }

    [System.Serializable]
    public class PoolObjectType
    {
        public string name;
        public GameObject prefab;
        public int count;
        [ReadOnly]
        public List<PoolObject> listPoolObjects=new List<PoolObject>();
    }
}
