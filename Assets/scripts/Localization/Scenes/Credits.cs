using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	[SerializeField] private Text credits;
	[SerializeField] private Text main;
	
	void Start () {
		credits.text = localization.Instance.getPhrase(11);
		main.text = localization.Instance.getPhrase(9);
	}
}
