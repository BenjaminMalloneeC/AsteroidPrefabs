﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Created enemy at the start
        GameManager.instance.enemiesList.Add(this.gameObject);
        //Aim at the player at start
    }

    // Update is called once per frame
    void Update()
    {
        //Always move forward
    }

    void OnDestroy()
    {
        //Removes enemy when they get destroyed
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //Gives name of object that player collided with
        Debug.Log("[Collision Enter] The GameObject of the other object is named: " + otherObject.gameObject.name);
        //Destroys asteroid and player on contact with player
        if (otherObject.gameObject == GameManager.instance.player)
        {
            //Destroys the player
            Destroy(otherObject.gameObject);
            //Destroys asteroid
            Destroy(this.gameObject);
        }
    }
}
