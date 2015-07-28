using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
	  if (other.tag == "Player"){
		player.GetComponent<ClickToMove>().rychlost -= 4;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player"){
		player.GetComponent<ClickToMove>().rychlost += 4;
		}
	}
}
