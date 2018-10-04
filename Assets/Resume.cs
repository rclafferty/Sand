using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

    private bool running, buttonUp;
	// Use this for initialization
	void Start ()
    {
        running = true;
        buttonUp = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(buttonUp)
        {
            if (running)
            {
                if (Input.GetAxis("Joy1Start") == 1 || Input.GetAxis("Joy2Start") == 1)
                {
                    running = false;
                    GetComponent<Renderer>().enabled = true;
                }
            }
            else
            {
                if (Input.GetAxis("Joy1Start") == 1 || Input.GetAxis("Joy2Start") == 1)
                {
                    running = true;
                    GetComponent<Renderer>().enabled = false;
                }
            }
        }

        if(Input.GetAxis("Joy1Start") == 1 || Input.GetAxis("Joy2Start") == 1)
        {
            buttonUp = false;
        }
        else
        {
            buttonUp = true;
        }
	}

    void OnMouseDown()
    {
        if(!running && GetComponent<Renderer>().enabled == true)
        {
            running = true;
            GetComponent<Renderer>().enabled = false;
        }
    }
}
