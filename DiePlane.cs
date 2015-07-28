using UnityEngine;
using System.Collections;

public class DiePlane : MonoBehaviour {


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
		player.GetComponent<Combat>().Die();
		Debug.Log("uhorel");
		}
	}
}


