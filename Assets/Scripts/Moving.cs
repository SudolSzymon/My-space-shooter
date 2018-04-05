using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
    private Rigidbody playerRigidBody;
    public int speed;
    public float xMin, xMax, zMin, zMax;
    public GameObject projectile;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire = 0;
    private AudioSource audio;
    void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
            audio.Play();
        }
		
	}
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidBody.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidBody.position -= transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidBody.position -= transform.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidBody.position += transform.right * Time.deltaTime * speed;

        }
        playerRigidBody.position = new Vector3(
            Mathf.Clamp(playerRigidBody.position.x,xMin,xMax),
            0.0f,
            Mathf.Clamp(playerRigidBody.position.z, zMin, zMax)


            );    

    }
}
