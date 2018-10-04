using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public int level;
    public GameObject holder;
	// Use this for initialization
	void Start ()
    {
        level = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (holder == null)
        {
            gameObject.transform.position += new Vector3(0, -0.5f, 0);
        }
        else
        {
            if(holder = GameObject.Find("Blue"))
            {
                if(Blue.direction == -1)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                gameObject.transform.position = new Vector3(holder.transform.position.x + Blue.direction * 0.5f, holder.transform.position.y - 1, 0);
            }
            else
            {
                if (Red.direction == -1)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                gameObject.transform.position = new Vector3(holder.transform.position.x + Red.direction * 0.5f, holder.transform.position.y - 1, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(holder == null)
        {
            if (other.gameObject == GameObject.Find("Blue"))
            {
                if (FistB.WeaponLevel < level)
                {
                    FistB.WeaponLevel = level;
                    if (FistB.holding != null)
                    {
                        Destroy(FistB.holding);
                    }
                    FistB.holding = gameObject;
                    holder = GameObject.Find("Blue");
                }
            }
            else if (other.gameObject == GameObject.Find("Red"))
            {
                if (FistR.WeaponLevel < level)
                {
                    FistR.WeaponLevel = level;
                    if (FistR.holding != null)
                    {
                        Destroy(FistR.holding);
                    }
                    FistR.holding = gameObject;
                    holder = GameObject.Find("Red");
                }
            }
        }
        
    }


}
