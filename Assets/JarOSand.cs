using UnityEngine;
using System.Collections;

public class JarOSand : MonoBehaviour
{
    public static GameObject holder;
    private static Rigidbody2D body;
	// Use this for initialization
	void Start ()
    {
        holder = null;
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.y < -35)
        {
            if (JarOSand.holder != null)
            {
                JarOSand.drop();
            }
            GameObject.Find("jar of sand").transform.position = new Vector3(0, -6, 0);
        }

	    if(holder != null)
        {
            if(holder == GameObject.Find("Blue").gameObject)
            {
                transform.position = new Vector3(holder.transform.position.x + (3 * Blue.direction), holder.transform.position.y - 2, 0);
                Blue.score += 1;
            }
            else if(holder == GameObject.Find("Red").gameObject)
            {
                transform.position = new Vector3(holder.transform.position.x + (3 * Red.direction), holder.transform.position.y - 2, 0);
                Red.score += 1;
            }

       
            
            
        }
        else
        {
            if (transform.position.y < -26 && transform.position.x < 64 && transform.position.x > -64)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        
	}

    public static void drop()
    {
        if(holder == GameObject.Find("Red").gameObject)
        {
            holder = null;
        }
        else if (holder == GameObject.Find("Blue").gameObject)
        {
            holder = null;
        }
        holder = null;
        GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().gravityScale = 1;
        GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        body.velocity = new Vector2(0, 15);
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if(holder == null)
        {
            if (theCollision.gameObject == GameObject.Find("Red").gameObject && Red.stunTimer <= 0)
            {
                holder = GameObject.Find("Red").gameObject;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().gravityScale = 0;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else if (theCollision.gameObject == GameObject.Find("Blue").gameObject && Blue.stunTimer <= 0)
            {
                holder = GameObject.Find("Blue").gameObject;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().gravityScale = 0;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GameObject.Find("jar of sand").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
    }


}
