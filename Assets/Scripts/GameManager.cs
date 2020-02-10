using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Sets the player prefab for respawning
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject asteroidPrefab;
    public static GameManager instance;
    //Number of lives
    public int lives = 3;
    public int score = 0;
    public bool isPaused = false;
    //Creates a list of enemies
    public List<GameObject> enemiesList = new List<GameObject>();

    public void Awake()
    {
        //Deletes a game manager, if more than one
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager.");
        }
    }

    private void Update()
    {
        //Quits the game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Spawns asteroid demonstration
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(asteroidPrefab);
        }

    }

    //Respawns the player when dies
    public void Respawn()
    {
        player = Instantiate(playerPrefab);
    }
}
