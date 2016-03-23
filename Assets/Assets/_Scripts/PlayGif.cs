using UnityEngine;
using System.Collections;
using System;

public class PlayGif : MonoBehaviour {
	public Sprite[] frames;
	public int framesPerSecond = 10;
	SpriteRenderer sr;

	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}

	void Update () {
		int index = (Convert.ToInt32(Time.time * framesPerSecond)) % frames.Length;
		sr.sprite = frames [index];
	}
}