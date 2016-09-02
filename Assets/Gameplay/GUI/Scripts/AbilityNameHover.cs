using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AbilityNameHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField] GameObject descriptionPanel;
	[SerializeField] string abilityDescription;

	public void OnPointerEnter(PointerEventData eventData)
	{
		descriptionPanel.SetActive (true);
		//descriptionPanel.transform.FindChild ("Description").GetComponent<Text> ().text = abilityDescription;
	}
	public void OnPointerExit(PointerEventData eventData) 
	{
		descriptionPanel.SetActive (false);
	}
}
