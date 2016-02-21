using UnityEngine;
using System.Collections;

public class WeaponSound : MonoBehaviour {

    [SerializeField] AudioSource audioSourceShot;
    [SerializeField] AudioSource audioSourceReload;

    public void playShotSound()
    {
        audioSourceShot.PlayOneShot(audioSourceShot.clip);
    }
    public void playReloadSound(float timeToReloadEnd)
    {
        Invoke("reloadSound", timeToReloadEnd - audioSourceReload.clip.length);
    }

    void reloadSound()
    {
        audioSourceReload.PlayOneShot(audioSourceReload.clip);
    }
}
