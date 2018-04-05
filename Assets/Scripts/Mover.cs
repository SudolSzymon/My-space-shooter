using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    Rigidbody body;
    public float speed;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        body.velocity = transform.forward * speed;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
