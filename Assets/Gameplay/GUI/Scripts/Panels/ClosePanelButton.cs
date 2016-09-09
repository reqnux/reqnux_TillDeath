using UnityEngine;
using System.Collections;

public class ClosePanelButton : MonoBehaviour {

	[SerializeField] GameObject panel;

    public void closePanel() 
    {
		panel.SetActive(false);
	}
}
