using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public List<GameObject> asteroids;
    public float initialSpawnTime;
    public Text score;
    private float nextSpawn = 0;
    private int scoreValue=0;
    private bool isPlaying = true;
    Vector3 spawnPoint;
    Quaternion spawnRotation;
    public Text restart;
    public Transform display;
    public GameObject player;
    private float spawnTime;
    Text restartText;
	// Use this for initialization
	void Start () {
        Screen.SetResolution(600, 900, false);
        spawnTime = initialSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)&&!isPlaying)
        {
            startPlay();

        }
		
	}
    private void FixedUpdate()
    {
        if (Time.time > nextSpawn&&isPlaying)
        {
            nextSpawn = Time.time + spawnTime;
            spawnPoint = new Vector3(Random.Range(-6, 6), 0, 20);
            spawnRotation = Quaternion.identity;
            Instantiate(asteroids[Random.Range(0,asteroids.Count)],spawnPoint,spawnRotation);
            if (spawnTime >= 0.1)
            {
                spawnTime=spawnTime*0.95f;
            }
            score.text = "Score: " + scoreValue;
        }
    }



    public void incrementScore()
    {
        scoreValue++;
    }
    public void decrementScore()
    {
        scoreValue--;
    }
    public void stopPlay()
    {
        isPlaying = false;
        restartText=Instantiate(restart, display);
    }
    private void startPlay()
    {
        isPlaying = true;
        Instantiate(player);
        scoreValue = 0;
        Destroy(restartText);
        spawnTime = initialSpawnTime;
    }

}
