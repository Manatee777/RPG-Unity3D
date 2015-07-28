using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization

	public float health;
	public float max_healt;

	public float str;
	public float dex;
	public float inteligence;
	public float basic_armor;

	public float mana;
	public float max_mana;

	public float hp_regen;
	public float hp_regen_multi;
	public float next_pos_regen;
	public float time_between_regens;

	public float mana_regen;
	public float mana_regen_multi;
	public float next_pos_mana_regen;
	public float time_between_mana_regen;

	public float get_damage;

	public AnimationClip smrt;

	public float experience;

	public GameObject level_system;
	public GameObject death_sound;
	 


	void Start () {


	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	public void TakeCloseDamage(float damage)
	{
		//damage = str + 5;
		health = health - damage + basic_armor;
		if (health <= 0)
		{
		Die ();
		}
    }


	public virtual void regeneruj(float healths_per_regen)
	{
		if (health>0){
		health += healths_per_regen;
			if (health > max_healt){
				health = max_healt;
			}
		}
	}

	public virtual bool regenerationTime()
	{
	    bool casRegenu = true;

		if (Time.time < next_pos_regen)
		{
		casRegenu = false;
		}
	    return casRegenu;
	}



	public virtual void regenerujManu (float mana_per_regen)
	{
		if (mana>0)
		{
		mana += mana_per_regen;
			if (mana > max_mana){
				mana = max_mana	;
			}
		}
	}

	public virtual bool manaRegenTime()
	{
		bool casManaRegenu = true;

		if (Time.time < next_pos_mana_regen) 
		{
			casManaRegenu = false;
		}

		return casManaRegenu;
	}


	public virtual void Die ()
	{
	//	animation.CrossFade (smrt.name);
	//	animation [smrt.name].wrapMode = WrapMode.Once;

		level_system.GetComponent<LevelSystem>().gain(experience);	

		Debug.Log (level_system.GetComponent<LevelSystem>().xps);
		Debug.Log ("gain");

	}



}
