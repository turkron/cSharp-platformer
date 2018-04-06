using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemToPickUp : PickUp {

	public string itemToAdd;

	protected override void payLoadFunction(){
		Debug.Log ("triggered");
		base.player.GetComponent<playerManager> ().inventory.Add (itemToAdd);
	}

}
