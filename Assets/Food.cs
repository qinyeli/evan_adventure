using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public Sprite[] foodSprites;

	void Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = foodSprites[Random.Range(0, foodSprites.Length)];
	}
}
