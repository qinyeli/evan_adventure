using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour {

	public GameObject rebornPoint;
	GameObject player;
	bool isSpawning = false;

	void OnTriggerEnter2D(Collider2D collider) {
		if (isSpawning) return;
		if (collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
			isSpawning = true;
			player = collider.gameObject;
			player.SetActive(false);
			Invoke("SpawnPlayer", 1f);
		}
	}

	void SpawnPlayer() {
		player.SetActive(true);
		player.transform.position = rebornPoint.transform.position;
		isSpawning = false;
	}
}
