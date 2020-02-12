using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    //Create a variable for our transform component
    private Transform tf;

    //Create a variable for the degree we rotate in one frame draw
    public float turnSpeed = 1.0f;
    public float movementSpeed = 1.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //Load our transform component into our variable
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate left when pushing left arrow
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate right when pushing right arrow
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Moves forward in local space
            tf.position += tf.right * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shoots bullets forward
            Shoot();

        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Player collision
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //Gives name of object that player collided with
        Debug.Log("[Collision Enter] The GameObject of the other object is named: " + otherObject.gameObject.name);
    }

    //Gives name of object that player leaves collision with
    void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("[Collision Exited] The GameObject of the other object is named: " + otherObject.gameObject.name);
    }

    void OnDestroy()
    {
        //If the player dies,they lose a life.
        GameManager.instance.lives -= 1;
        if (GameManager.instance.lives > 0)
        {
            GameManager.instance.Respawn();
        }
        else
        {
            //Console tells that player that the game is over
            Debug.Log("Game Over!");
        }
    }
}
