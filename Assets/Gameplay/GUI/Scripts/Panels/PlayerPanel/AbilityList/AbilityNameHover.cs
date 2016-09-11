using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AbilityNameHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField] GameObject descriptionPanel;

	public void OnPointerEnter(PointerEventData eventData)
	{
		descriptionPanel.SetActive (true);
		SpecialAbilityName abilityEnumName = transform.parent.GetComponent<PlayerPanelAbilityRow> ().Ability.EnumName;

		descriptionPanel.transform.FindChild ("AbilityName").GetComponent<Text> ().text 
			= SpecialAbilitiesDescriptions.names[abilityEnumName];
		descriptionPanel.transform.FindChild ("Description").GetComponent<Text> ().text 
			= SpecialAbilitiesDescriptions.descriptions[abilityEnumName];
	}
	public void OnPointerExit(PointerEventData eventData) 
	{
		descriptionPanel.SetActive (false);
	}
}
