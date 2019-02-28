﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public enum AudioChannel {Master, Sfx, Music}

	public float masterVolumePercent { get; private set; }
	public float sfxVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }

    AudioSource [] musicSources;
	int activeMusicSourceIndex;

	public static AudioManager Instance;

	Transform audioListener;
	Transform playerT;


	SoundLibrary library;

	void Awake(){
		if (Instance != null) {
			Destroy (gameObject);
		}
		else{
			Instance = this;
			DontDestroyOnLoad (gameObject);
			musicSources = new AudioSource[2];
			for (int i =0; i < 2; i++){
				GameObject newMusicSource = new GameObject ("Music Source " + (i + 1));
				musicSources [i] = newMusicSource.AddComponent <AudioSource> ();
				newMusicSource.transform.parent = transform;
			}
			audioListener = FindObjectOfType <AudioListener> ().transform;
        
			 
			library = GetComponent <SoundLibrary>();

			masterVolumePercent = PlayerPrefs.GetFloat ("master vol", 1);
			sfxVolumePercent = PlayerPrefs.GetFloat ("sfx vol", 1);
			musicVolumePercent = PlayerPrefs.GetFloat ("music vol", 1);
		}
	}

	void Update (){
		playerT = GameObject.Find ("_Player").transform;

		if (playerT != null) {
			audioListener.position = playerT.position;
		}
	}

	public void SetVolume (float volumePercent, AudioChannel channel){
		switch (channel) { 
		case AudioChannel.Master:
			masterVolumePercent = volumePercent;
			break;
		case AudioChannel.Sfx:
			sfxVolumePercent = volumePercent;
			break;
		case AudioChannel.Music:
			musicVolumePercent = volumePercent;
			break;
		}
		musicSources [0].volume = musicVolumePercent * masterVolumePercent;
		musicSources [1].volume = musicVolumePercent * masterVolumePercent;

		PlayerPrefs.SetFloat ("master vol", masterVolumePercent);
		PlayerPrefs.SetFloat ("sfx vol", sfxVolumePercent);
		PlayerPrefs.SetFloat ("music vol", musicVolumePercent);
        PlayerPrefs.Save ();
	}

	public void PlayMusic (AudioClip AudioClip, float fadeDuration =1){
		activeMusicSourceIndex = 1 - activeMusicSourceIndex;
		musicSources [activeMusicSourceIndex].clip = AudioClip;
		musicSources [activeMusicSourceIndex].Play ();
		StartCoroutine (AnimateMusicCrossfade (fadeDuration)); 
	}

	public void Playsound (AudioClip clip, Vector3 pos ){
		if (clip != null){
			AudioSource.PlayClipAtPoint (clip, pos, sfxVolumePercent *masterVolumePercent);
		}
	}
	public void PlaySound (string soundName, Vector3 pos){
		Playsound (library.GetClipFromName (soundName), pos);
	}



	IEnumerator AnimateMusicCrossfade(float duration){
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * 1 / duration; 
			musicSources [activeMusicSourceIndex].volume = Mathf.Lerp (0, musicVolumePercent * masterVolumePercent, percent); 
			musicSources [1-activeMusicSourceIndex].volume = Mathf.Lerp (musicVolumePercent * masterVolumePercent, 0, percent); 
			yield return null;
		}
	}

//	public void playNow(){
		
	//}
}
