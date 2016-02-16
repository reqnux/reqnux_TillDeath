using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoDisplay : MonoBehaviour {

    private Player player;
    private Text ammoText;

    void Awake() 
    {
        ammoText = GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update () 
    {
        ammoText.text = getAmmoText();
    }

    private string getAmmoText() 
    {
        if(player.CurrentWeapon.Reloading)
            return "--/" + player.CurrentWeapon.ClipSize;
        else
            return player.CurrentWeapon.CurrentAmmo + "/" + player.CurrentWeapon.ClipSize;
    }
}
