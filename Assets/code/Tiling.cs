using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;

	public bool hasARight = false;
	public bool hasALeft = false;

	public bool reverseScale = false;

	private float spriteWidth = 0f;

	private Camera cam;
	private Transform myTransform;

	void Awake()
	{
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x;


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!hasALeft || !hasARight) {
			float camHorizontalExtent = cam.orthographicSize * Screen.width / Screen.height;

			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtent;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtent;

			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARight) {
				MakeNewTile (1);
				hasARight = true;

			} 
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasALeft) {
				MakeNewTile (-1);
				hasALeft = true;
			}
				
		}
	}


	void MakeNewTile(int direction)
	{
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth *  direction * myTransform.localScale.x, myTransform.position.y, myTransform.position.z);
		Transform newTile = (Transform) Instantiate (myTransform, newPosition, myTransform.rotation);

		if (reverseScale) {
			newTile.localScale = new Vector3 (newTile.localScale.x*-1, newTile.localScale.y, newTile.position.z);
		}

		newTile.parent = myTransform.parent;

		if (direction > 0) {
			newTile.GetComponent<Tiling> ().hasALeft = true;
		} else {
			newTile.GetComponent<Tiling> ().hasARight = true;
		}
	}
}
