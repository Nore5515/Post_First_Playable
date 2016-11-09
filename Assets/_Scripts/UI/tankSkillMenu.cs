using UnityEngine;
using System.Collections;

public class tankSkillMenu : MonoBehaviour {

	public GameObject tankMenu;
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

	public bool spMenu2 = false;

	public expSystem xpSys;
	public levelingMenu attackMenu;
	public agilitySkillMenu agilitySkills;
	
	// Use this for initialization
	void Start () {

		attackMenu.attackSkillMenu.SetActive (false);
		tankMenu.SetActive (false);
		agilitySkills.agilityMenu.SetActive (false);
		
		//xpSys = GetComponent<expSystem>();
		attackMenu = GetComponent<levelingMenu>();
		agilitySkills = GetComponent<agilitySkillMenu>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (spMenu2) {
			
			//UnityEngine.Cursor.visible = true;
			tankMenu.SetActive (true);
			Time.timeScale = 0;
		}
		
		if (!spMenu2) {
			
			//UnityEngine.Cursor.visible = false;
			tankMenu.SetActive (false);
			Time.timeScale = 1;
		}

	}
	
	public void returnToMenu()
	{
		attackMenu.spMenu = false;
		spMenu2 = false;
		agilitySkills.spMenu3 = false;
	}
	
	public void attackSkillMenu()
	{
		attackMenu.spMenu = true;
		spMenu2 = false;
		agilitySkills.spMenu3 = false;
	}
	
	public void agilitySkillMenu()
	{
		attackMenu.spMenu = false;
		spMenu2 = false;
		agilitySkills.spMenu3 = true;
	}
	
	public void Skill1()
	{
		//if (xpSys.skillPoint >= 1)
		//{
			armor = 2;
			Debug.Log(armor);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
	}
	
	public void Skill2()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (armor >= 2)
			{*/
				healthregen = 1;
				Debug.Log(healthregen);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
		//}
	}
	
	public void Skill3()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (armor >= 2)
			{*/
				damageReduction = 1;
				Debug.Log(damageReduction);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
		//}
	}
	
	public void Skill4()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (armor >= 2)
			{*/
				consumableHealth = 1;
				Debug.Log(consumableHealth);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
		//}
	}
	
	public void Skill5()
	{
		/*if (xpSys.skillPoint >= 1)
		{
			if (armor >= 2)
			{*/
				hpBurst = 1;
				Debug.Log(hpBurst);
		xpSys.skillPoint -= 1;
		Debug.Log(xpSys.skillPoint);
		//}
		//}
	}
}
