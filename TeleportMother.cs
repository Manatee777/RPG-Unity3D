using UnityEngine;
using System.Collections;

public class TeleportMother : MonoBehaviour {


	public Transform player;
	public Transform teleport_son;
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
			other.transform.position = teleport_son.transform.position;
		}
	}
}
