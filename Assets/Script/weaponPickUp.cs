using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUp : PickUp {

	public int weaponToUnlock;

	protected override void payLoadFunction(){

		Debug.Log ("triggered");
		base.player.GetComponent<weaponHandling> ().weapons[weaponToUnlock].Unlocked = true;

	}

}
