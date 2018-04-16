using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerSpawner : MonoBehaviour {


    public GameObject seeker;
    public float spawnInterval;
    public int spawnCount;
   
    float spawnTime;
    ObjectPool pool;

    private void Start()
    {
        pool = GetComponent<ObjectPool>();
    }

    void poolSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnedSeeker = pool.getObject();
            spawnedSeeker.SetActive(true);
            spawnedSeeker.transform.position = transform.position + (Random.insideUnitSphere * spawnCount);
        }
    }
    void spawn()
    {
        for(int i =0; i < spawnCount; i++)
        {
            GameObject spawnedSeeker = Instantiate(seeker);
            spawnedSeeker.transform.position = transform.position + (Random.insideUnitSphere * spawnCount);
        }
       
    }

	// Update is called once per frame
	void Update ()
    {
        spawnTime -= Time.deltaTime;
       
        if(spawnTime <= 0)
        {
            spawn();
            spawnTime = spawnInterval;
        }
       
	}
}
