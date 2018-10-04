using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Red : MonoBehaviour
{

    private Rigidbody2D body;
    private bool hitCoolingDown, jumpContinue;
    public static bool punching;
    private GameObject floor;
    public static int direction, hitTimer, health, maxHealth, stunTimer, slashTimer;
    public static float stun;
    public float yMove, xMove, speed = 1, jump = 150, vSpeed;
    public bool grounded;
    public Animator animator;

    public static int score = 0;

    public static int maxLives, currlife;
    public Text livescounter;
    public Text scorecounter;
    public Image healthBar;
    // Use this for initialization

    void Start()
    {
        slashTimer = 0;
        jumpContinue = false;
        stunTimer = 0;
        body = GetComponent<Rigidbody2D>();
        yMove = 0;
        xMove = 0;
        hitCoolingDown = false;
        direction = -1;
        hitTimer = -1;
        health = 100;
        maxHealth = 100;
        punching = false;
        stun = 0;

        vSpeed = 0;
        animator = gameObject.GetComponent<Animator>();

        maxLives = 3;
        currlife = maxLives;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)health / maxHealth;

        livescounter.text = "Lives: " + currlife.ToString();

        scorecounter.text = "Score: " + score.ToString();



        if (stunTimer <= 0)
        {
            if(xMove < 2 && Input.GetAxis("Horizontal") == 1)
            {
                xMove += 0.2f;
            }
            else if(xMove > -2 && Input.GetAxis("Horizontal") == -1)
            {
                xMove -= 0.2f;
            }
            else if(Input.GetAxis("Horizontal") == 0)
            {
                if(xMove > 0.1f)
                {
                    xMove -= 0.1f;
                }
                else if(xMove < -0.1f)
                {
                    xMove += 0.1f;
                }
                else
                {
                    xMove = 0;
                }
            }

            if (Input.GetAxis("Joy1Jump") == 1 && grounded)
            {
                jumpContinue = true;
                yMove = jump;
            }
            else if(Input.GetAxis("Joy1Jump") == 1 && jumpContinue)
            {
                yMove -= 2.5f;
            }
            else
            {
                if(jumpContinue && yMove > 10)
                {
                    jumpContinue = false;
                    yMove = 0;
                }
                yMove -= 5;
            }
        }
        else
        {
            xMove = stun;
        }

        body.velocity = new Vector2(xMove * speed, yMove);

        if (transform.position.y < -40 || transform.position.y > 100)
        {
            FistR.WeaponLevel = 0;
            health = 100;
            stunTimer = 50;
            currlife -= 1;
            gameObject.transform.position = new Vector3(50, 0, 0);
            stun = 0;
            if(currlife <= 0)
            {
                MasterCommandProgram.redDead = true;
                Destroy(GameObject.Find("Red"));
            }
        }

        if ((int)Input.GetAxis("Horizontal") > 0)
        {
            direction = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if ((int)Input.GetAxis("Horizontal") < 0)
        {
            direction = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (hitCoolingDown)
        {
            punching = false;
        }

        if (!hitCoolingDown && stunTimer <= 0)
        {
            if (Input.GetAxis("Joy1Punch") == 1)
            {
                hitCoolingDown = true;
                punching = true;
                if (direction == 1)
                {
                    slashTimer = 5;
                    GameObject.Find("FistR").transform.position = transform.position;
                    GameObject.Find("FistR").transform.position = new Vector3(transform.position.x + 5, transform.position.y, 0);
                }
                else
                {
                    slashTimer = 5;
                    GameObject.Find("FistR").transform.position = transform.position;
                    GameObject.Find("FistR").transform.position = new Vector3(transform.position.x - 5, transform.position.y, 0);
                }
            }
            else if (Input.GetAxis("Joy1Kick") == 1)
            {
                hitCoolingDown = true;
                punching = true;
                if (direction == 1)
                {
                    slashTimer = 5;
                    GameObject.Find("FistR").transform.position = transform.position;
                    GameObject.Find("FistR").transform.position = new Vector3(transform.position.x + 5, transform.position.y - 4, 0);
                }
                else
                {
                    slashTimer = 5;
                    GameObject.Find("FistR").transform.position = transform.position;
                    GameObject.Find("FistR").transform.position = new Vector3(transform.position.x - 5, transform.position.y - 4, 0);
                }
            }
        }
        else if (Input.GetAxis("Joy1Punch") == 0 && Input.GetAxis("Joy1Kick") == 0)
        {
            hitCoolingDown = false;
        }

        if(!punching)
        {
            GameObject.Find("FistR").transform.position = new Vector3(1000,1000,1000);
        }

        if (hitTimer >= 0)
        {
            hitTimer -= 1;
        }

        if(stunTimer > 0)
        {
            stunTimer -= 1;
            if(stunTimer > 5 && stunTimer % 10 > 5)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (slashTimer > 0)
        {
            slashTimer -= 1;
            if(FistR.WeaponLevel == 1)
            {
                GameObject.Find("SwordR1").GetComponent<Renderer>().enabled = true;
            }
            else if(FistR.WeaponLevel == 2)
            {
                GameObject.Find("SwordR2").GetComponent<Renderer>().enabled = true;
            }
            else if(FistR.WeaponLevel ==3)
            {
                GameObject.Find("SwordR3").GetComponent<Renderer>().enabled = true;
            }
        }
        else
        {
            if (FistR.WeaponLevel == 1)
            {
                GameObject.Find("SwordR1").GetComponent<Renderer>().enabled = false;
            }
            else if (FistR.WeaponLevel == 2)
            {
                GameObject.Find("SwordR2").GetComponent<Renderer>().enabled = false;
            }
            else if (FistR.WeaponLevel == 3)
            {
                GameObject.Find("SwordR3").GetComponent<Renderer>().enabled = false;
            }
        }

        vSpeed = Mathf.Abs(xMove);
        animator.SetFloat("vSpeed", vSpeed);
        animator.SetBool("grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        foreach (ContactPoint2D contact in theCollision.contacts)
        {
            if (contact.normal.y > 0.5)
            {
                grounded = true;
                yMove = 0;
                floor = theCollision.gameObject;
            }
        }

    }

    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject == floor)
        {
            grounded = false;
            floor = null;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }


}