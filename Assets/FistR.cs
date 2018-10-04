using UnityEngine;
using System.Collections;

public class FistR : MonoBehaviour
{
    public static int WeaponLevel;
    public static GameObject holding;
    // Use this for initialization
    void Start()
    {
        WeaponLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponLevel == 1)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 10);
        }
        else if (WeaponLevel == 2)
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
        if (other.gameObject == GameObject.Find("Blue") && Blue.stunTimer <= 0)
        {
            Blue.health -= 5;
            Blue.stunTimer = 20;
            Blue.stun = Red.direction * 0.2f;
            if (JarOSand.holder == other.gameObject)
            {
                JarOSand.drop();
            }
            if (Blue.health <= 0)
            {
                Blue.stun = 0;
                Blue.health = 100;
                Blue.stunTimer = 50;
                Blue.currlife -= 1;
                other.transform.position = new Vector3(-50, 0, 0);
            }
        }

        if (other.gameObject.GetComponent<Skeleton>().enabled)
        {
            Destroy(other.gameObject);
        }
    }


}