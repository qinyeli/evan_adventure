using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour {
	static WorldSwitcher instance;
	public static WorldSwitcher Instance {
		get {
			if (instance == null) {
				GameObject go = new GameObject("WorldSwitcher");
				instance = go.AddComponent<WorldSwitcher>();
				return instance;
			}
			return instance;
		}
	}

	public GameObject[] snowWorldObjects;
	public GameObject[] sandWorldObjects;
	
	public enum World {
		snowWorld,
		sandWorld
	}
	public World currentWorld { get; private set; }

	void Start() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);

		currentWorld = World.snowWorld;
		DeactivateAll(sandWorldObjects);
		ActivateAll(snowWorldObjects);
	}

	public void Switch() {
		if (currentWorld == World.sandWorld) {
			currentWorld = World.snowWorld;
			DeactivateAll(sandWorldObjects);
			ActivateAll(snowWorldObjects);
		} else if (currentWorld == World.snowWorld) {
			currentWorld = World.sandWorld;
			DeactivateAll(snowWorldObjects);
			ActivateAll(sandWorldObjects);
		}
	}

	void ActivateAll(GameObject[] objects) {
		for (int i = 0; i < objects.Length; i++) {
			objects[i].SetActive(true);
		}
	}

	void DeactivateAll(GameObject[] objects) {
		for (int i = 0; i < objects.Length; i++) {
			objects[i].SetActive(false);
		}
	}
}
