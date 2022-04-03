using UnityEngine;

public class Ship : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int moneyDrop = 300;
    [SerializeField] private GameObject diver;

    public new void die()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(diver, transform.position, Quaternion.identity);
        }
        var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.gainMoney(moneyDrop);
        Destroy(gameObject);
    }
}
