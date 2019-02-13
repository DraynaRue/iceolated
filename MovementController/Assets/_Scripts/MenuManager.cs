﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public Slider[] sliderVolumes;
	public Toggle[] resolutionToggles;
	public int[] screenWidths;
	public Toggle fullscreenToggle;
	int activeScreenResIndex;
	public GameObject loadingScreen;
	public Slider slider;
	public Text progressPercentage;

	void Start(){
		activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
		bool isFullscreen = (PlayerPrefs.GetInt ("fullscreen") ==1)?true:false;

        sliderVolumes[0].value = AudioManager.Instance.masterVolumePercent;
        sliderVolumes[1].value = AudioManager.Instance.sfxVolumePercent;
        sliderVolumes[2].value = AudioManager.Instance.musicVolumePercent;

        for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].isOn = i == activeScreenResIndex;
		}
		fullscreenToggle.isOn = isFullscreen;

	}

	public void Play(int sceneIndex){
		mainMenuHolder.SetActive (false);
		StartCoroutine (LoadAsynchronously(sceneIndex));
	}
	public void Quit(){
		Application.Quit ();
	}

	public void OptionsMenu(){
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);

	}

	public void MainMenu(){
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
	}


	public void SetScreenResolution(int i){
		if (resolutionToggles [i].isOn) {
			activeScreenResIndex = i;
			float aspectRatio = 16 / 9f;
			Screen.SetResolution (screenWidths[i], (int)(screenWidths[i]/aspectRatio), false);
			PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
			PlayerPrefs.Save ();
		}
	}

	public void SetFullscreen(bool isFullscreen){
		for(int i = 0; i < resolutionToggles.Length; i++){
			resolutionToggles [i].interactable = !isFullscreen;
				}
		if (isFullscreen) {
			Resolution[] allResolutions = Screen.resolutions;
			Resolution maxResolution = allResolutions [allResolutions.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true); 
		} 
		else {
			SetScreenResolution (activeScreenResIndex);
		}
		PlayerPrefs.SetInt ("fullscreen", ((isFullscreen) ? 1 : 0));
		PlayerPrefs.Save ();
	}

	public void SetMasterVolume(float value){
        AudioManager.Instance.SetVolume(value, AudioManager.AudioChannel.Master);
	}

	public void SetMusicVolume(float value){
        AudioManager.Instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

	public void SetSfxVolume (float value){
        AudioManager.Instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }

	IEnumerator LoadAsynchronously(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingScreen.SetActive (true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			slider.value = progress;
			progressPercentage.text = progress * 100f + (" %");
			yield return null;
		}
	}
}
