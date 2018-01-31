using UnityEngine;

public class GameManager : MonoBehaviour {
	static GameManager instance;

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
