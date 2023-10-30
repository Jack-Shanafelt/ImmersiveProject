using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // sets the bullet to be "destroyed" after 5 seconds if still in the scene.
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checks to see if the bullet collides with the enmy gameObject.
        if (collision.gameObject.name == "Enemy")
        {
            // if so it destroys the enemy game object and the bullet.
            // Enemy has to be destroyed first
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
