using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controls : MonoBehaviour {

	[SerializeField] private Text controls;
	[SerializeField] private Text main;
	[SerializeField] private Text shoot;
	[SerializeField] private Text movement;
	
	void Start () {
		controls.text = localization.Instance.getPhrase(12);
		main.text = localization.Instance.getPhrase(9);
		shoot.text = localization.Instance.getPhrase(13);
		movement.text = localization.Instance.getPhrase(14);
	}
}
