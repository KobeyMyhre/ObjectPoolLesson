using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public GameObject pooledObject;
    public Stack<GameObject> pool;
    //public int activeAmount;

   
    public int pooledAmount;


    // Spawns prefab, adds to a stack, and assigns parent to this object
    void Start()
    {
        pool = new Stack<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            var spawnedObj = Instantiate(pooledObject);
            spawnedObj.transform.SetParent(transform);
            spawnedObj.GetComponent<PooledObject>().myPool = this;
            spawnedObj.SetActive(false);
            pool.Push(spawnedObj);
        }
    }

    //Returns the object at the top of the stack, grows the stack if it is empty
    public GameObject getObject()
    {
        if (pool.Count > 0)
        {
            return pool.Pop();
        }
        else
        {
            pooledAmount *= 2;
            for (int i = 0; i < pooledAmount; i++)
            {
                var spawnedObj = Instantiate(pooledObject);
                spawnedObj.transform.parent = transform;
                spawnedObj.GetComponent<PooledObject>().myPool = this;
                spawnedObj.SetActive(false);
                pool.Push(spawnedObj);
            }
            Debug.Log("Pool Is Empty");

            return pool.Pop();
        }
    }
}
