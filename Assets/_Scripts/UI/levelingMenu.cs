using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class levelingMenu : MonoBehaviour {

	public GameObject attackSkillMenu;
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

	public bool spMenu = false;

	public expSystem xpSys;
	public tankSkillMenu tankSkills;
	public agilitySkillMenu agilitySkills;
	public EnemyHealth playerDamage;

	// Use this for initialization
	void Start () {

		tankSkills = GameObject.Find ("Main Camera").GetComponent<tankSkillMenu> ();
		attackSkillMenu = GameObject.Find ("UI_Levelling").transform.FindChild("AttackTree").gameObject;
		agilitySkills = GameObject.Find ("Main Camera").GetComponent<agilitySkillMenu> ();

		xpSys = GetComponent<expSystem>();
		tankSkills = GetComponent<tankSkillMenu>();
		agilitySkills = GetComponent<agilitySkillMenu>();

		playerDamage = GameObject.FindGameObjectWithTag("attack").GetComponent<EnemyHealth>();

		attackSkillMenu = GameObject.Find ("AttackTree");

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.L)) {
			
			spMenu = !spMenu;
		}

		else
		{
			attackSkillMenu.SetActive (false);
			tankSkills.tankMenu.SetActive (false);
			agilitySkills.agilityMenu.SetActive (false);
		}
		
		if (spMenu) {
			
			//UnityEngine.Cursor.visible = true;
			attackSkillMenu.SetActive (true);
			Time.timeScale = 0;
		}
		
		if (!spMenu) {
			
			//UnityEngine.Cursor.visible= false;
			attackSkillMenu.SetActive (false);
			Time.timeScale = 1;
		}
		
	}

	public void returnToMenu()
	{
		spMenu = false;
		tankSkills.spMenu2 = false;
		agilitySkills.spMenu3 = false;
	}

	public void tankSkillMenu()
	{
		spMenu = false;
		agilitySkills.spMenu3 = false;

		tankSkills.spMenu2 = true;
	}

	public void agilitySkillMenu()
	{
		spMenu = false;
		tankSkills.spMenu2 = false;
		agilitySkills.spMenu3 = true;
	}

	public void Skill1()
	{
		if (xpSys.skillPoint >= 1 && attack == 1)
		{
			attack = 2;
			Debug.Log(attack);

			playerDamage.damage = 20.0f;
			Debug.Log(playerDamage.damage);

			xpSys.skillPoint -= 1;
			Debug.Log(xpSys.skillPoint);
			Debug.Log ("Attack = 2");
		}
	}

	public void Skill2()
	{
		if (xpSys.skillPoint >= 1)
		{
			if (attack == 2)
			{
				attack = 3;
				Debug.Log(attack);

				breath = 1;
				Debug.Log(breath);

				playerDamage.damage = 30.0f;
				Debug.Log(playerDamage.damage);

				xpSys.skillPoint -= 1;
				Debug.Log(xpSys.skillPoint);
				Debug.Log ("Attack = 3");
			}
		}
	}

	public void Skill3()
	{
		if (xpSys.skillPoint >= 1)
		{
			if (attack == 3)
			{
				attack = 4;
				Debug.Log(attack);

				playerDamage.damage = 40.0f;
				Debug.Log(playerDamage.damage);

				xpSys.skillPoint -= 1;
				Debug.Log(xpSys.skillPoint);
			}
		}
	}

	public void Skill4()
	{
		if (xpSys.skillPoint >= 1)
		{
			if (attack == 2)
			{
				attack = 5;
				Debug.Log(attack);
				
				playerDamage.damage = 50.0f;
				Debug.Log(playerDamage.damage);

				xpSys.skillPoint -= 1;
				Debug.Log(xpSys.skillPoint);
				Debug.Log ("Attack = 5, damage increased to max!");
			}
		}
	}

	public void Skill5()
	{
		if (xpSys.skillPoint >= 1)
		{
			if (attack == 5)
			{
				meleeElemental = 1;
				Debug.Log(meleeElemental);

				xpSys.skillPoint -= 1;
				Debug.Log(xpSys.skillPoint);


			}
		}
	}
}