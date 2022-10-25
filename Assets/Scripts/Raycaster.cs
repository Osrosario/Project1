using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Raycast function returns a bool, so in order to tell what we hit we use the "out" keyword to update our RaycastHit variable with the thing we hit.
 * This lets us use the Raycast function inside the if statement (true if we hit something) and then inside we can use our hit info.
 */

public class Raycaster : MonoBehaviour
{
	private float speed;
	//public float time;
	
	private void Start()
	{
		speed =1f;
		//range = (pointA, pointB);
	}

	private void Update()
	{
		transform.position = new Vector3(-Mathf.Sin(Time.time * speed) * 13f, 0f, transform.position.z);

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			Restart restartOn = hit.collider.gameObject.GetComponent<Restart>();
			if (hit.collider.gameObject.CompareTag("Player") == true)
			{
				Debug.Log("hit");
				Debug.DrawLine(transform.position, hit.point, Color.green);
				restartOn.RestartHit();
			}
			else
			{
				Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.red);
				Debug.Log("no hit");	
			}
		}
	}
}