using UnityEngine;

public class Boat : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int moneyDrop = 80;
}
