using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	ScreenFader screenFader;

	void Start() {
		screenFader = gameObject.GetComponent<ScreenFader>();
	}

	void Update () {
		if (Input.anyKeyDown) {
			screenFader.EndScene("SceneGamePlay");
		}
	}
}
