using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    public Transform target;
    public float z;
	// Use this for initialization
	void Start ()
    {
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(target.position.x, target.position.y, z);
	}
}
