using UnityEngine;

public class LevelManager : MonoBehaviour {
	static LevelManager instance;

	void Start() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		if (Input.GetButtonDown(InputSettings.SWITCH)) {
			WorldSwitcher.Instance.Switch();
		}
	}
}
