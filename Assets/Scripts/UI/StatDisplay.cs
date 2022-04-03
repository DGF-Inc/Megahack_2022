using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text waveText;

    private void Update()
    {
        healthText.text = "♥" + gameManager.getHealth().ToString();
        moneyText.text =  "$" + gameManager.getMoney().ToString();
        waveText.text = "Wave " + waveManager.getCurrentWave().ToString();
    }
}
