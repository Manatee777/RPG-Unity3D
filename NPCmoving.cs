using UnityEngine;
using System.Collections;

public class NPCmoving : Character {
	
	
	public float rychlost;

	
	

	
	public CharacterController charcontroler;
	public Transform player;
	
	public GameObject koliznik;
	
	public AnimationClip beh;
	public AnimationClip klid;
	public AnimationClip utok;
	

	
	
	public bool dosahBool = false;
	
	//waypoints
	public GameObject[] waypoints;
	public int current_waypoint = 0;
	public Vector3 range;
	
	public AudioClip kousanec;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		

			
			
			
				range = waypoints[current_waypoint].transform.position - transform.position;
			
			if (range.magnitude < 1)
			{
				current_waypoint++;
			
				if (current_waypoint == waypoints.Length)
				{
				current_waypoint = 0;
			}
			}
			
			else 
			{
				rigidbody.velocity = range.normalized * transform.GetComponent<NPCmoving>().rychlost;
				animation.CrossFade(gameObject.GetComponent<NPCmoving>().beh.name);
				transform.LookAt(waypoints[current_waypoint].transform);
		}
			

		
		
		
	}
		
		

		
	
	

}
