using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MasterCommandProgram : MonoBehaviour
{
    private int maxEntityNumber, totalTime;
    public GameObject[] entities;
    public GameObject spriteToDuplicate;
    Random randy = new Random();
    private int toSpawn;

    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Vector3 cameraPos;
    public Text goscreen;
    public static bool redDead, blueDead;



    // Use this for initialization
    void Start ()
    {
        goscreen.text = "";
        redDead = false;
        blueDead = false;
        toSpawn = 1;
        totalTime = 0;
        maxEntityNumber = 30;
        entities = new GameObject[maxEntityNumber];



        

    }

    // Update is called once per frame
    void Update ()
    {
        totalTime += 1;
        if(totalTime % 400 == 0)
        {
            for(int i = 0; i < toSpawn; i++)
            {
                Vector3 position = new Vector3(Random.Range(-60, 60), Random.Range(-20, 20), 0);
                GameObject tempObj = GameObject.Instantiate(spriteToDuplicate, position, Quaternion.identity) as GameObject;
            }

            if(totalTime % 2000 == 0)
            {
                toSpawn += 1;
            }
        }


        if (redDead && blueDead)
        {
            
            goscreen.text = "GAME OVER !!!!";
            



            }
    }


}
