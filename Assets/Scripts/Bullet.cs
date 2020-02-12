using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tf;
    public float bulletSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Always move forward
        tf.position += tf.right * bulletSpeed * Time.deltaTime;
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
