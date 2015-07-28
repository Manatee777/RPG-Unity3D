using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	public GameObject[] waypoints;
	public int current_waypoint = 0;
	public Vector3 range;
	public AnimationClip beh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (transform.GetComponent<Mob>().umrel_jsem == false && transform.GetComponent<Mob>().dosahBool == false)
	{

		range = waypoints[current_waypoint].transform.position - transform.position;

		if (range.magnitude < 5)
		{
			current_waypoint++;

			if (current_waypoint == waypoints.Length)
			{
				current_waypoint = 0;
			}
		}

		else 
		{
		rigidbody.velocity = range.normalized * transform.GetComponent<Mob>().rychlost;
				animation.CrossFade(gameObject.GetComponent<Mob>().beh.name);
		transform.LookAt(waypoints[current_waypoint].transform);
		}
	}



	}
}
