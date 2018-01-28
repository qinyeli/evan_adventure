using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlayer : MonoBehaviour {
	static BGMPlayer instance;
	public static BGMPlayer Instance {
		get {
			if (instance == null) {
				GameObject go = new GameObject("BGMPlayer");
				instance = go.AddComponent<BGMPlayer>();
				return instance;
			}
			return instance;
		}
	}

	[Header("Music Settings")]
	public AudioClip musicAudioClip;
	public bool musicPlayOnAwake = true;
	[Range(0f, 1f)]
	public float musicVolume = 1f;

	[Header("Ambient Settings")]
	public AudioClip ambientAudioClip;
	public bool ambientPlayOnAwake = true;
	[Range(0f, 1f)]
	public float ambientVolume = 1f;

	AudioSource musicAudioSource;
	AudioSource ambientAudioSource;

	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		if (musicAudioClip != null) {
			musicAudioSource = gameObject.AddComponent<AudioSource> ();
			musicAudioSource.clip = musicAudioClip;
			musicAudioSource.loop = true;
			musicAudioSource.volume = musicVolume;
			if (musicPlayOnAwake) musicAudioSource.Play();
		}

		if (ambientAudioClip != null) {
			ambientAudioSource = gameObject.AddComponent<AudioSource>();
			ambientAudioSource.clip = ambientAudioClip;
			ambientAudioSource.loop = true;
			ambientAudioSource.volume = ambientVolume;
			if (ambientPlayOnAwake) ambientAudioSource.Play();
		}
	}

	public void Play() {
		if (musicAudioSource != null) musicAudioSource.Play();
		if (ambientAudioSource != null) ambientAudioSource.Play();
	}

	public void Stop() {
		if (musicAudioSource != null) musicAudioSource.Stop();
		if (ambientAudioSource != null) ambientAudioSource.Stop();
	}

	public void Mute(float fadeTime) {
		if (musicAudioSource != null)
			StartCoroutine(VolumeFade(musicAudioSource, 0f, fadeTime));
		if (ambientAudioSource != null)
			StartCoroutine(VolumeFade(ambientAudioSource, 0f, fadeTime));
	}

	public void Unmute(float fadeTime) {
		if (musicAudioSource != null)
			StartCoroutine(VolumeFade(musicAudioSource, 0f, fadeTime));
		if (ambientAudioSource != null)
			StartCoroutine(VolumeFade(ambientAudioSource, 0f, fadeTime));
	}

	IEnumerator VolumeFade (AudioSource source, float finalVolume, float fadeTime) {
		float volumeDiff = Mathf.Abs(source.volume - finalVolume);
		while (!Mathf.Approximately(source.volume, finalVolume)) {
			float deltaVolume = volumeDiff / fadeTime * Time.deltaTime;
			source.volume = Mathf.MoveTowards(source.volume, finalVolume, deltaVolume);
			yield return null;
		}
		source.volume = finalVolume;
	}
}
