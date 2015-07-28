using UnityEngine;
using System.Collections;

public class Combat : Character {


	public GameObject nepritel; 

	public AnimationClip utok;

	public AnimationClip stit;

	public GameObject s_sword;

	public double casUderu;
	public bool zasazen;


	public float nextposatack;
	public float timebetweenatacks;
	public float atackperminute;

	public static bool invul;


	public float hpregen = 2;
	public float manaregen = 2;

	public float fight_skill = 0;
	public float fight_skill_gain = 50;





	void Start () {

		timebetweenatacks = 60 / atackperminute;

		get_damage = str * 2;
	
	}



	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			kryt();
			if (nepritel != null) {
				transform.LookAt (nepritel.transform);
			}

		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
						
						animation.CrossFade (utok.name);
						animation [utok.name].wrapMode = WrapMode.Once;
			
						ClickToMove.utok = true;
						zasazen = true;

						if (nepritel != null) 
			            {
								transform.LookAt (nepritel.transform);
								if (Vector3.Distance (nepritel.transform.position, transform.position) < 2) 
			                  	{
								 if (CasUtoku ()) 
					               {
						           nextposatack = Time.time + timebetweenatacks;
						           uder();
				                   }
								 }
			             }
			                  
        }



		if (this.health < this.max_healt)
		{

			if (regenerationTime ())
			{
				
				next_pos_regen = Time.time + time_between_regens;
				regeneruj (hpregen);
			
			}
		}



		if (this.mana < this.max_mana) 
		{
			
			if (manaRegenTime ()) 
			{
				
				next_pos_mana_regen = Time.time + time_between_mana_regen;
				regenerujManu(manaregen);
				
			}
		}




		if(!animation.IsPlaying(utok.name))
		{
			ClickToMove.utok = false;
			zasazen = false;
		}


		if(!animation.IsPlaying(stit.name))
		{
			ClickToMove.kryji_se = false;
			invul = false;

		}

		if(!animation.IsPlaying(smrt.name))
		{
			ClickToMove.umiram = false;
			
		}

		
		if(animation.IsPlaying(smrt.name))
		{
			ClickToMove.umiram = true;
			
		}


		if (animation.IsPlaying(stit.name))
		{

			invul = true;
		}


		//if (RotationTime())
		//{
		//	next_pos_rotate = Time.time + animation[smrt.name].length;
		//	transform.Rotate(270,0,0);
		//}


	}


	void uder()
	{
		zasazen = true;

		StartCoroutine(DoAtack());
		fight_skill += 1;

		if (fight_skill > fight_skill_gain)
		{

			fight_skill_gain = fight_skill_gain + 50;
			transform.GetComponent<Character>().str += 3;
			transform.GetComponent<Character>().max_healt += 3;
			transform.GetComponent<ClickToMove>().rychlost += 0.25f;
		}
	 }

	IEnumerator DoAtack()
	{

		yield return new WaitForSeconds(0.85f); // wait for two seconds.
		nepritel.GetComponent<Character>().TakeCloseDamage(get_damage);
		s_sword.GetComponent<Sound>().seknuto();
		Debug.Log (nepritel.GetComponent<Character>().health);
		
		
	}


	void kryt()
	{
		animation.CrossFade (stit.name);
		animation[stit.name].wrapMode = WrapMode.Once;
		Debug.Log ("kryju se");
		ClickToMove.kryji_se = true;

	}
	

	private bool CasUtoku()
	{
		bool casUtoku = true;
		
		
		if (Time.time < nextposatack) {
			casUtoku = false;
		}
		
		return casUtoku;
	}

	public override void regeneruj(float healths_per_regen)
	{
		base.regeneruj (healths_per_regen);

	}

	public override bool regenerationTime()
	{
		bool casRegenu = true;
		
		if (Time.time < next_pos_regen) {
			casRegenu = false;
		}
		
		return casRegenu;
	}


	public override void regenerujManu(float mana_per_regen)
	{
		base.regenerujManu (mana_per_regen);
		
	}


	public override bool manaRegenTime()
	{
		bool casManaRegenu = true;
		
		if (Time.time < next_pos_mana_regen) 
		{
			casManaRegenu = false;
		}
		
		return casManaRegenu;
	}




	public float nextpostdead;
	public float time_between_dead;

	public override void Die()
	{
		base.Die ();




		if(afterDeathTime()){
		nextpostdead = Time.time + time_between_dead;

			StartCoroutine(DoAnimation());

			

		}

	}



	public bool afterDeathTime()
	{
		bool afterdeathtime = true;
		
		if (Time.time < nextpostdead) 
		{
			afterdeathtime = false;
		}
		
		return afterdeathtime;
	}


	IEnumerator DoAnimation()
	{
		animation.CrossFade(smrt.name);
		animation[smrt.name].wrapMode = WrapMode.Once;
		yield return new WaitForSeconds(2.1f); // wait for two seconds.
		animation[smrt.name].speed = 0;
		Time.timeScale = 0;


	}


	//public float next_pos_rotate;
	//public float time_between_rotate;

	//public bool RotationTime()
	//{
	//	bool rotationTime = true;
		
	//	if (Time.time < next_pos_rotate) 
	//	{
		//	rotationTime = false;
	//	}
		
	//	return rotationTime;
	//}

}


