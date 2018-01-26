using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(PlatformerMotor2D))]
public class Player : MonoBehaviour {

	public int countItem;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer == LayerMask.NameToLayer("Item")) {
			countItem++;
			Destroy(collider.gameObject);
		}
	}
}
