using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PC2D;

[RequireComponent(typeof(Collider2D),typeof(PlatformerMotor2D))]
public class Player : MonoBehaviour {

	public int countCorn = 0;
	public Text countCornText;
	public GameObject cornGridLayer;
	string totalNumCorn;
	
	public int countFood = 0;
	public Text countFoodText;
	public GameObject foodGridLayer;
	string totalNumFood;

	bool prevIsInWater = false;
	bool currIsInWater = false;

	bool prevIsOnIce = false;
	bool currIsOnIce = false;

	PlatformerMotor2D motor;

	void Start () {
		motor = GetComponent<PlatformerMotor2D>();

		int _totalNumCorn = cornGridLayer.transform.childCount;
		totalNumCorn = "/" + _totalNumCorn.ToString();
		countCornText.text = countCorn.ToString() + totalNumCorn;

		int _totalNumFood = foodGridLayer.transform.childCount;
		totalNumFood = "/" + _totalNumFood.ToString();
		countFoodText.text = countFood.ToString() + totalNumFood;
	}
	
	void Update () {
		currIsInWater = motor.isInWater;
		if (currIsInWater && !prevIsInWater) {
			AudioManager.Instance.PlaySFX(AudioManager.SFXName.JumpIntoWater);
		}
		prevIsInWater = currIsInWater;

		currIsOnIce = motor.isOnIce && (motor.motorState == PlatformerMotor2D.MotorState.OnGround);
		if (currIsOnIce && !prevIsOnIce) {
			AudioManager.Instance.PlaySFX(AudioManager.SFXName.JumpOntoIce);
		}
		prevIsOnIce = currIsOnIce;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.layer == LayerMask.NameToLayer("Collectable")) {
			AudioManager.Instance.PlaySFX(AudioManager.SFXName.GetItem);
			if (collider.gameObject.tag == "Corn") {
				countCorn ++;
				countCornText.text = countCorn.ToString() + totalNumCorn;
			}
			if (collider.gameObject.tag == "Food") {
				countFood ++;
				countFoodText.text = countFood.ToString() + totalNumFood;
			}
			Destroy(collider.gameObject);
		}
	}
}
