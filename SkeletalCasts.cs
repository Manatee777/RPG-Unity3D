using UnityEngine;
using System.Collections;

public class SkeletalCasts : RangeEnemyCast {


	public GameObject fireball_efekt;

	public Transform fireball_spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (transform.position, player.transform.position) < 6) 
		{
			fireball();	
		}
	
	}

	public override void UtocneKouzlo (float distance, float casttime)
	{
		base.UtocneKouzlo (distance, casttime);
	}

	void fireball()
	{
		UtocneKouzlo (15, 2);

		if (efect_release == true) 
		{
			Instantiate (fireball_efekt, fireball_spawn.position, fireball_spawn.rotation);
		}
	}



}
