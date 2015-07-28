using UnityEngine;
using System.Collections;

public class CastSystem : MonoBehaviour {

	public GameObject nepritel;

	public float nextposspeell;
	public float timebetweenspells;
	public float castperminute;

	public float spelldamage;


	public bool efect_release;

	public Transform player_target;

	public float cast_skill = 1;
	public float cast_skill_gain = 50;



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

	public virtual void UtocneKouzlo(float distance, float casttime, float mana_cost)
	{
		if (player_target.GetComponent<Character>().mana > mana_cost)
		{
			//	if (nepritel != null) 
			//    {
			timebetweenspells = casttime;
			//transform.LookAt(nepritel.transform);
			 //if(Vector3.Distance(nepritel.transform.position, transform.position) < distance)
			{

				if (CasKouzel())
				{
					nextposspeell = Time.time + timebetweenspells;
					efect_release = true;
					Debug.Log("utocne kouzlo!");
					player_target.GetComponent<Character>().mana -= mana_cost;

					cast_skill += 1;
					
					if (cast_skill > cast_skill_gain){
						
						cast_skill_gain = cast_skill_gain + 50;
						transform.GetComponent<Character>().inteligence += 3;
						transform.GetComponent<Character>().max_mana += 3;

					}
				}

					else efect_release = false;
			}
		}
		else efect_release = false;

	}





	public virtual void ObranneKouzlo(float healed, float casttime, float mana_cost)
	{


		if (player_target.GetComponent<Character>().mana > mana_cost)
		{
		if (transform != null) 
		{
		
			timebetweenspells = casttime;

				if (CasKouzel())
				{
					
					nextposspeell = Time.time + timebetweenspells;
					Debug.Log("healuju se!");
				player_target.GetComponent<Character>().mana -= mana_cost;

				}

				else efect_release = false;
			}
		}
		else efect_release = false;
	}






}
