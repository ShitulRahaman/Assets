using UnityEngine;
using System.Collections;

public class GameSoundEffecter : MonoBehaviour
{

	public bool isGame = false;
	public AudioClip[] BackGroundSoundClip;
	public AudioClip JumpSoundClip;
	public AudioClip ButtonSoundClip;
	public AudioClip PopUpSoundClip;
	public AudioClip DeadSoundClip;
	public AudioClip CheakPointSoundClip;
	public AudioClip DamegeSoundClip;
	public AudioClip BalloonSoundClip;


	public AudioSource AudioPlayerBg;
	private AudioSource SoundPlayer;

	public static GameSoundEffecter GameSoundEffect;
	// Use this for initialization
	void Start ()
	{
		GameSoundEffect = this;
		SoundPlayer = gameObject.GetComponent<AudioSource> ();
		//AudioPlayerBg = GetComponentInChildren<AudioSource> ();

		AudioPlayerBg.volume=GameUtility.GameSoundVolume;
			
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{
		AudioPlayerBg.volume=GameUtility.GameSoundVolume;
		if (AudioPlayerBg.isPlaying) {
			if (!GameUtility.GameSoundOn) {
				AudioPlayerBg.Pause();

			}
		} else {
			if (GameUtility.GameSoundOn) {
				AudioPlayerBg.UnPause();
				AudioPlayerBg.volume=GameUtility.GameSoundVolume;
			}
		
		}
	}
		

	public void ButtonSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (ButtonSoundClip);
		}
	}

	public void PopUpSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (PopUpSoundClip);
		}
	}



	//Game Screen Sound
	public void GameOverSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			AudioPlayerBg.clip=BackGroundSoundClip[1];
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (DeadSoundClip);
		}
	}

	public void CheckPontFlagSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (CheakPointSoundClip);
		}
	
	}

	public void DamgeSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (DamegeSoundClip);
		}

	}

	public void BalloonSoundPlay ()
	{
		if (GameUtility.GameSoundOn) {
			if (SoundPlayer.isPlaying) {
				SoundPlayer.Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (BalloonSoundClip);
		}

	}

	public  void JumpSpund ()
	{
		if (GameUtility.GameSoundOn) {
			if (gameObject.GetComponentInChildren<AudioSource> ().isPlaying) {
				gameObject.GetComponentInChildren<AudioSource> ().Stop ();
			}
			SoundPlayer = GetComponentInChildren<AudioSource> ();
			SoundPlayer.volume = GameUtility.GameSoundVolume;
			SoundPlayer.PlayOneShot (JumpSoundClip);

		}
	   
	}
}
