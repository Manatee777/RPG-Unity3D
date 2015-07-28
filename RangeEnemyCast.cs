using UnityEngine;
using System.Collections;

public class RangeEnemyCast : MonoBehaviour {
	
	public Transform player;
	
	public float nextposspeell;
	public float timebetweenspells;
	public float castperminute;
	
	public float spelldamage;
	
	
	public bool efect_release;
	
	
	
	// Use this for initialization
	void Start () {
		
		
		
		timebetweenspells = 60 / castperminute;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	
	
	
	
	public virtual bool CasKouzel()
	{
		bool casKouzel = true;
		efect_release = true;
		
		
		if (Time.time < nextposspeell) {
			casKouzel = false;
			efect_release = false;
		}
		
		return casKouzel; 
		
	}
	
	public virtual void UtocneKouzlo(float distance, float casttime)
	{
		
		
		if (player != null) 
		{
			timebetweenspells = casttime;

			if(Vector3.Distance(transform.position, player.transform.position) < distance)
			{
				if(player.GetComponent<Character>().health>0){
				if (CasKouzel())
				{
					
					nextposspeell = Time.time + timebetweenspells;
					efect_release = true;
						audio.Play ();
					Debug.Log("utocne kouzlo!");
					
					
					
				}
				
				else efect_release = false;

				}
			}
			
		}

		
	
		
		
		
	}
	
	
	

		
		
		
		

	
	
}
