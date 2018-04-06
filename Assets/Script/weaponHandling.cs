using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHandling : MonoBehaviour {

	public GameObject bulletPrefab;

	public int currentWeapon = 0;
	public int currentWeaponCD = 0;

	public float mouseDistanceToPlayer;

	public class WeaponDefinitions
	{
		public string wepName {get; set;}
		public bool Unlocked{get; set;}
		public int Dmg{get; set;}
		public int CD{get; set;}
		public float Accur{get; set;}
		public int NumOfPellets{get; set;}
		public WeaponDefinitions(){}
		public WeaponDefinitions(string name, bool unlocked, int dmg, int cd , float accur , int numOfPellets){
			wepName = name;
			Unlocked = unlocked;
			Dmg = dmg;
			CD = cd;
			Accur = accur;
			NumOfPellets = numOfPellets;
		}

	}

	public WeaponDefinitions[] weapons = new WeaponDefinitions[]{
		new WeaponDefinitions(){wepName = "pistols", Unlocked= true, Dmg= 2, CD= 10, Accur= 1.0f, NumOfPellets=1},
		new WeaponDefinitions(){wepName = "shotgun", Unlocked= false, Dmg= 2, CD= 100, Accur= 1.2f, NumOfPellets=5}
	};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWeaponCD >= 1) {
			currentWeaponCD--;
		}

		if(Input.GetKeyDown(KeyCode.E)){
			changeCurrentWeaponTo (getNextUnlockedWeapon());
		}

		if(Input.GetKeyDown(KeyCode.Q)){
			changeCurrentWeaponTo (getPrevUnlockedWeapon());
		}

		if (Input.GetMouseButton (1)) {
			//send command that is currently using a ranged attack so cannot melee. 
			var zCam = -Camera.main.transform.position.z;
			var mPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zCam));

			FireHeldWeapon (currentWeapon, mPos);

		}
			

		mouseDistanceToPlayer = ((Input.mousePosition - Camera.main.WorldToScreenPoint (this.transform.position)).magnitude) / 100;
		if (mouseDistanceToPlayer > 1) {mouseDistanceToPlayer = 1;}
		////Debug.Log (mouseDistanceToPlayer);
		
	}

	void FireHeldWeapon (int currentWeapon, Vector3 mPos)
	{
		if (checkWeaponReadyState ()) {
			createBullets (currentWeapon, mPos);
			currentWeaponCD = getWeaponCD (currentWeapon);
		}
	}

	int getWeaponCD(int currentWeapon){return weapons [currentWeapon].CD;}
	float getWeaponAccur(int currentWeapon){return weapons [currentWeapon].Accur;}
	bool checkWeaponReadyState (){return currentWeaponCD == 0;}
	int getNumberOfPellets(int currentWeapon){return weapons [currentWeapon].NumOfPellets;}

	void createBullets(int currentWeapon, Vector3 mPos){
		// need to take into account the accur of a weapon where spawn bullets. 

		//need to also take into account the amount of bullets that need to be created. 
		for (int i = 0; i < getNumberOfPellets (currentWeapon); i++) {
			mPos = modifymPos (mPos, getWeaponAccur(currentWeapon));
			Instantiate (bulletPrefab, this.transform.position, Quaternion.LookRotation (mPos - transform.position));
		}

	}


	// need to take into account range from mousePos to player. DONE
	Vector3 modifymPos(Vector3 mPos, float currentWeaponAccur){
		// need to work out distance of mouse to player. DONE
		return new Vector3((mPos.x + getRandomNumberFromRange(currentWeaponAccur)*(mouseDistanceToPlayer)),(mPos.y + getRandomNumberFromRange(currentWeaponAccur))* (mouseDistanceToPlayer), 0.0f);
	}

	//need random bullet div from acc; DONE
	float getRandomNumberFromRange(float range){
		return Random.Range(-range, range);
	}

	int changeWeapon(int input){
		return currentWeapon += input;
	}

	void changeCurrentWeaponTo(int newEquipedWeapon){
		currentWeapon = newEquipedWeapon;
	}

	int getNextUnlockedWeapon(){
		for (int i = currentWeapon += 1; i < weapons.Length; i++) {
			if (weapons [i].Unlocked) {
				return i;
			}
		}
		return 0;
	}

	int getPrevUnlockedWeapon(){

		if (currentWeapon > 0) {
			for (int i = currentWeapon -= 1; i > -2; i--) {
				if (weapons [i].Unlocked) {
					Debug.Log ("rtning " + i);
					return i;
				}
			}
		} else {
			for (int j = weapons.Length-1; j > 0; j--) {
				if (weapons [j].Unlocked) {
					return j;
				}
			}
		}
		return 0;
	}




}
