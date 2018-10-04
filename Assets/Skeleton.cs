using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (gameObject.GetComponent<EnemyAI>().target.transform.position.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if(theCollision.gameObject == GameObject.Find("Red") && Red.stunTimer <= 0)
        {
            Red.health -= 5;
            Red.stunTimer = 20;
            if(gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Red.stun = 0.2f;
            }
            else
            {
                Red.stun = -0.2f;
            }

            if (JarOSand.holder == theCollision.gameObject)
            {
                JarOSand.drop();
            }
            if (Red.health <= 0)
            {
                Red.stun = 0;
                Red.health = 100;
                Red.stunTimer = 50;
                Red.currlife -= 1;
                theCollision.transform.position = new Vector3(50, 0, 0);
            }
        }
        else if(theCollision.gameObject == GameObject.Find("Blue") && Blue.stunTimer <= 0)
        {
            Blue.health -= 5;
            Blue.stunTimer = 20;
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Blue.stun = 0.2f;
            }
            else
            {
                Blue.stun = -0.2f;
            }

            if (JarOSand.holder == theCollision.gameObject)
            {
                JarOSand.drop();
            }
            if (Blue.health <= 0)
            {
                Blue.stun = 0;
                Blue.health = 100;
                Blue.stunTimer = 50;
                Blue.currlife -= 1;
                theCollision.transform.position = new Vector3(-50, 0, 0);
            }
        }

    }


}
