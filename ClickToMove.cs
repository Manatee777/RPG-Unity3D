using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	private Vector3 pozice;
	public float rychlost;

	public CharacterController charcontroler;

	public static bool utok;

	public static bool kryji_se;

	public static bool umiram;

	public AnimationClip beh;
	public AnimationClip klid;
	// Use this for initialization
	void Start () {
	
		pozice = transform.position;  //nastavi pozci objektu na tu na ktere se prave na scene nachazi, jinak by sel na origin point
	}
	
	// Update is called once per frame
	void Update () {  //vola se kazdy frame
	 
		if ((!utok) && (!kryji_se) && (!umiram)) 
		{   
			if (Input.GetMouseButton (0))
			{				
			locatePosition ();
			}
			moveToPosition ();
		} 
	}

	
	void locatePosition()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //ray se nastavi tam kam miri myš

		if (Physics.Raycast (ray, out hit, 1000))	//fyzika zacne pocitat raycast s parametrem naseho paprstu a vracenim hitu			
		{
			 if (hit.collider.tag != "Player")
			{  //kdyz klikneme na sebe nebudeme menit pozici logicky
			pozice = new Vector3(hit.point.x, hit.point.y, hit.point.z);//ray nakresli caru, hit vrati jeji koncovy bod
            }
		}
	}


	void moveToPosition()
	{
		if (Vector3.Distance (transform.position, pozice) > 1) 
		{ //pokud je rozdil mezi soucasnou pozici a vychozi mensi nez 1
				
						Quaternion newRotation = Quaternion.LookRotation (pozice - transform.position, Vector3.forward); 
						newRotation.x = 0f; //zakaz rotace vertikalne
						newRotation.z = 0f;
						transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);//stredni doba mezi soucasnou a budouci rotaci pro plynulost
						charcontroler.SimpleMove (transform.forward * rychlost); 
			animation.CrossFade(beh.name);
		} 

		else
		{
			animation.CrossFade(klid.name);
		}
			

	}

}
