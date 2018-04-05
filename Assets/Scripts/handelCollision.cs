using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handelCollision : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameControl gameControl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Boundrary" || other.tag=="Asteroid" )
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameControl.incrementScore();
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameControl.decrementScore();
            gameControl.stopPlay();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControl = gameControllerObject.GetComponent<GameControl>();
        }
        if (gameControl == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
