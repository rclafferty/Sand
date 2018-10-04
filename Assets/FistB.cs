using UnityEngine;
using System.Collections;

public class FistB : MonoBehaviour
{
    public static int WeaponLevel;
    public static GameObject holding;
    // Use this for initialization
    void Start()
    {
        WeaponLevel = 0;
    }

    // Update is called once per frame
    void Update ()
    {
	    if(WeaponLevel == 1)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 10);
        }
        else if(WeaponLevel == 2)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(10, 15);
        }
        else if (WeaponLevel == 3)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(20, 30);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.Find("Red") && Red.stunTimer <= 0)
        {
            Red.health -= 5;
            Red.stunTimer = 20;
            Red.stun = Blue.direction * 0.2f;
            if (JarOSand.holder == other.gameObject)
            {
                JarOSand.drop();
            }
            if (Red.health <= 0)
            {
                Red.stun = 0;
                Red.health = 100;
                Red.stunTimer = 50;
                Red.currlife -= 1;
                other.transform.position = new Vector3(50, 0, 0);
            }
        }

        if(other.gameObject.GetComponent<Skeleton>().enabled)
        {
            Destroy(other.gameObject);
        }

    }


}
