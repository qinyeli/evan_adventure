using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(PlatformerMotor2D))]
public class Player : MonoBehaviour {

	public int countCorn = 0;
	public int countFood = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer == LayerMask.NameToLayer("Collectable")) {
			if (collider.gameObject.tag == "Corn") {
				countCorn ++;
			}
			if (collider.gameObject.tag == "Food") {
				countFood ++;
			}
			Destroy(collider.gameObject);
		}
	}
}
