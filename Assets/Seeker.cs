using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour {


    GameObject player;
    Rigidbody rb;
    public float speed;
    public float lifeTime;
    float lifeTimer;
    PooledObject obj;
    // Use this for initialization
    void Start ()
    {
        obj = GetComponent<PooledObject>();
        rb = GetComponent<Rigidbody>();
        float rando = Random.Range(1, 7);
        transform.localScale = Vector3.one * rando;
        float r = Random.Range(50, 206);
        float g = Random.Range(50, 206);
        float b = Random.Range(50, 206);
        GetComponent<Renderer>().material.color = new Color(r,g,b,1);
        player = GameObject.Find("Player");
        lifeTimer = lifeTime;
	}
	

    public void resetSeeker()
    {
        lifeTimer = lifeTime;
    }

	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = player.transform.position - transform.position;
        rb.AddForce(dir.normalized * speed);
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
            //if (obj != null)
            //{
            //    resetSeeker();
            //    obj.returnToPool();
            //}
            //else
            //{
            //    Destroy(gameObject);
            //}

        }
    }

    
}
