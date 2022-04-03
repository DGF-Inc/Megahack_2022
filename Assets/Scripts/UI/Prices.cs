using UnityEngine;
using UnityEngine.UI;

public class Prices : MonoBehaviour
{
	[SerializeField] private Text pricesText;

	[SerializeField] private GameObject piranhaPrefab;
	[SerializeField] private GameObject jellyfishPrefab;
	[SerializeField] private GameObject seacucumberPrefab;
	[SerializeField] private GameObject sharkPrefab;

	private void Start()
	{
		string str = "";
		str += "Piranha: $" + piranhaPrefab.GetComponent<Piranha>().cost + " (1)\n";
		str += "Jellyfish: $" + jellyfishPrefab.GetComponent<Jellyfish>().cost + " (2)\n";
		str += "Sea Cucumber: $" + seacucumberPrefab.GetComponent<SeaCu>().cost + " (3)\n";
		str += "Shark: $" + sharkPrefab.GetComponent<Shark>().cost + " (4)\n";
		pricesText.text = str;
	}
}
