using UnityEngine;
using System.Collections;

public class WeaponSound : MonoBehaviour {

    [SerializeField] AudioSource audioSourceShot;
    [SerializeField] AudioSource audioSourceReload;

    public void playShotSound()
    {
		if(audioSourceShot != null)
			GameManager.AudioManager.play (audioSourceShot, AudioType.BulletShot);
    }
    public void playReloadSound(float timeToReloadEnd)
    {
        Invoke("reloadSound", timeToReloadEnd - audioSourceReload.clip.length);
    }

    void reloadSound()
    {
		if(audioSourceReload != null)
			GameManager.AudioManager.play (audioSourceReload, AudioType.Other);
    }
}
