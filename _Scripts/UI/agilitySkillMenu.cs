using UnityEngine;
using System.Collections;

public class agilitySkillMenu : MonoBehaviour {

	public GameObject agilityMenu;
	public float attackSkill = 0;
	public float armorSkill = 0;
	public float agilitySkill = 0;
	public float attack = 1;
	public float breath = 0;
	public float meleeElemental = 0;
	
	public float armor = 1;
	public float healthregen = 0;
	public float hpBurst = 0;
	public float consumableHealth = 0;
	public float damageReduction = 0;
	public bool invincibility = false;
	public float elementalShroud = 0;
	
	public float agility = 1;
	public float maneuvers = 0;
	public float movementSpeed = 1;
	public float timeInAir = 0;
	public bool wings = false;
	public bool slowTime = false;

	public bool spMenu3 = false;

	public expSystem xpSys;
	public tankSkillMenu tankSkills;
	public levelingMenu attackMenu;
	
	// Use this for initialization
	void Start () {
		
		attackMenu.attackSkillMenu.SetActive (false);
		tankSkills.tankMenu.SetActive (false);
		agilityMenu.SetActive (false);
		
		//xpSys = GetComponent<expSystem>();
		tankSkills = GetComponent<tankSkillMenu>();
		attackMenu = GetComponent<levelingMenu>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (spMenu3) {
			
			//UnityEngine.Cursor.visible = true;
			agilityMenu.SetActive (true);
			Time.timeScale = 0;
		}
		
		if (!spMenu3) {
			
			//UnityEngine.Cursor.visible = false;
			agilityMenu.SetActive (false);
			Time.timeScale = 1;
		}
	}
	
	public void returnToMenu()
	{
		attackMenu.spMenu = false;
		tankSkills.spMenu2 = false;
		spMenu3 = false;
	}
	
	public void tankSkillMenu()
	{
		attackMenu.spMenu = false;
		spMenu3 = false;
		
		tankSkills.spMenu2 = true;
	}
	
	public void attackSkillMenu()
	{
		attackMenu.spMenu = true;
		tankSkills.spMenu2 = false;
		spMenu3 = false;
	}
	
	public void Skill1()
	{
		//if (xpSys.skillPoint >= 1)
		//{
			agility = 2;
			Debug.Log(agility);
		//}
	}
	
	public void Skill2()
	{
		/*if (xpSys.skillPoint >= 1)
		{*/
			movementSpeed = 2;
			Debug.Log(movementSpeed);

		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
	}
	
	public void Skill3()
	{
		/*if (xpSys.skillPoint >= 1)
		{*/
			maneuvers = 1;
			Debug.Log(maneuvers);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
	}
	
	public void Skill4()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (agility == 2)
			{*/
				wings = true;
				Debug.Log(wings);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
		//}
	}
	
	public void Skill5()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (agility == 2)
			{*/
				timeInAir = 1;
				Debug.Log(timeInAir);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		/*}
		}*/
	}
}