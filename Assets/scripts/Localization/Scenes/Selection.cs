using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

	[SerializeField] private Text selectSub;
	[SerializeField] private InputField enterName;
	
	void Start () {
		selectSub.text = localization.Instance.getPhrase(2);
		enterName.text = localization.Instance.getPhrase(3);
	}
}
