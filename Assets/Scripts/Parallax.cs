using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float smoothing = 1f;

	Transform[] backgrounds;
	float[] parallaxScales;

	Transform cam;
	Vector3 previousCamPos;

	void Start() {
		cam = Camera.main.transform;
		previousCamPos = cam.position;

		backgrounds = gameObject.GetComponentsInChildren<Transform>();
		parallaxScales = new float[backgrounds.Length];
		for (int i = 0 ; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z;
		}
		print(backgrounds.Length);
	}
	
	void Update() {
		for (int i = 0 ; i < backgrounds.Length; i++) {
			Vector3 deltaPos = (cam.position - previousCamPos) * parallaxScales[i];
			deltaPos.z = 0;
			Vector3 targetPos = backgrounds[i].position + deltaPos;
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,
					targetPos, smoothing * Time.deltaTime);
		}

		previousCamPos = cam.position;
	}
}
