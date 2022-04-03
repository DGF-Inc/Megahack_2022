using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool enabled = true;
    
    [SerializeField] private GameObject piranhaPrefab;
    [SerializeField] private GameObject jellyfishPrefab;
    [SerializeField] private GameObject sharkPrefab;
    [SerializeField] private GameObject seaCucumberPrefab;

    private Piranha piranha;
    private Jellyfish jellyfish;
    private Shark shark;
    private SeaCu seaCucumber;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        piranha = piranhaPrefab.GetComponent<Piranha>();
        jellyfish = jellyfishPrefab.GetComponent<Jellyfish>();
        shark = sharkPrefab.GetComponent<Shark>();
        seaCucumber = seaCucumberPrefab.GetComponent<SeaCu>();
    }

    private enum buyFishEnum
	{
        None,
        Piranha,
        Jellyfish,
        SeaCucumber,
        Shark
	}

    private buyFishEnum buyFish = buyFishEnum.None;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        buy();
    }

    public void buy()
    {
        if (!enabled) return;
        
		if (Input.GetKeyDown(KeyCode.Alpha1) && gameManager.getMoney() >= piranha.getCost())
		{
            buyFish = buyFishEnum.Piranha;
		}
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameManager.getMoney() >= jellyfish.getCost())
        {
            buyFish = buyFishEnum.Jellyfish;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && gameManager.getMoney() >= seaCucumber.getCost())
        {
            buyFish = buyFishEnum.SeaCucumber;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && gameManager.getMoney() >= shark.getCost())
        {
            buyFish = buyFishEnum.Shark;
        }
		if (Input.GetMouseButtonDown(1))
		{
            buyFish = buyFishEnum.None;
		}

		if (Input.GetMouseButtonDown(0))
        {
            if (!enabled) return;
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            
            if (buyFish != buyFishEnum.None) gameManager.playSoundPlace();

            switch (buyFish)
            {
                case buyFishEnum.Piranha:
                    piranha.spawn(mousePosition);
                    gameManager.gainMoney(-piranha.getCost());
                    buyFish = buyFishEnum.None;
                    break;
                case buyFishEnum.Jellyfish:
                    jellyfish.spawn(mousePosition);
                    gameManager.gainMoney(-jellyfish.getCost());
                    buyFish = buyFishEnum.None;
                    break;
                case buyFishEnum.SeaCucumber:
                    seaCucumber.spawn(mousePosition);
                    gameManager.gainMoney(-seaCucumber.getCost());
                    buyFish = buyFishEnum.None;
                    break;
                case buyFishEnum.Shark:
                    shark.spawn(mousePosition);
                    gameManager.gainMoney(-shark.getCost());
                    buyFish = buyFishEnum.None;
                    break;
                
            }

        }
		
    }

    public void setEnabled(bool isEnabled)
    {
        enabled = isEnabled;
    }
}
