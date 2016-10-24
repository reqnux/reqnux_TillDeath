using UnityEngine;
using System.Collections;

public class WeaponSound : MonoBehaviour {

    [SerializeField] AudioSource audioSourceShot;
    [SerializeField] AudioSource audioSourceReload;

    public void playShotSound()
    {
		if(audioSourceShot != null)
        	audioSourceShot.PlayOneShot(audioSourceShot.clip);
    }
    public void playReloadSound(float timeToReloadEnd)
    {
        Invoke("reloadSound", timeToReloadEnd - audioSourceReload.clip.length);
    }

    void reloadSound()
    {
		if(audioSourceReload != null)
        	audioSourceReload.PlayOneShot(audioSourceReload.clip);
    }
}
