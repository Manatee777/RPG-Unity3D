using UnityEngine;
using System.Collections;

public class TeleportSon : MonoBehaviour {


	public Transform player;
	public Transform teleport_mother;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.position = teleport_mother.transform.position;
		}
	}
}
