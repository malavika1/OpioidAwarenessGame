using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
	private AudioSource[] audioSources;
	private AudioSource _audioSource;

	private void Awake()
	{
		MusicPlayer[] m = FindObjectsOfType<MusicPlayer> ();
		if (m.Length > 1) {
			Destroy (this.gameObject);
			return;
		}


		DontDestroyOnLoad(this);
		audioSources = GetComponents<AudioSource>();

		if (audioSources.Length > 0 && _audioSource == null) {
			_audioSource = audioSources [0];
		}
		PlayMusic ();
	}		

	public void PlayMusic()
	{
		if (_audioSource.isPlaying) return;
		_audioSource.Play();
	}

	public void StopMusic()
	{
		_audioSource.Stop();
	}

	public void changeMusic(int index) {
		if (audioSources == null || index < 0 || index >= audioSources.Length) {
			return;
		}
		if (_audioSource != null) {
			StopMusic ();
		}
		this._audioSource = audioSources[index];
		PlayMusic ();
	}

	public bool isActive() {
		return _audioSource != null && _audioSource.isPlaying;
	}
}