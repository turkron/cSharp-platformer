using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPowerUp : PickUp {

	protected override void payLoadFunction(){

		Debug.Log ("triggered");
		base.player.GetComponent<PlayerMovement> ().maxJumps++;

	}

}
