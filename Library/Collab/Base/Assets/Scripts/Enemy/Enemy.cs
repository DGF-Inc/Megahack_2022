using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	/**
	 *	Variables that declare the enemies basic values
	 */
    public float speed;
    public int health;
    public int damage;
    public float progress;
    public int moneyDrop;

    private GameManager gameManager;

    /**
     * Data the enemies need to move on the map
     */
    private Vector3[] checkpoints;
    private Vector3 nextCheckpoint;
    private int nextCheckpointIndex = 0;


    /**
     *	Sets the first next checkpoint to the first checkpoint in the list
     */
    void Start()
    {
	    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	    checkpoints = gameManager.getCheckpoints();
	    nextCheckpoint = checkpoints[0];
    }

    void Update()
    {
	    move();
        attack();
    }
    
    /**
     *	Spawns a new enemy at the location given via the spawnPoint variable
     */
    public void spawn(Vector3 spawnPoint)
    {
        Instantiate(gameObject, spawnPoint, Quaternion.identity);
    }

    /**
     *	Despawns the enemy if it has less than zero health
     */
    public void die()
    {
	    gameManager.gainMoney(moneyDrop);
        Destroy(gameObject);
    }

    /**
     *	Damages the corals if enemy reaches end
     */
    public void attack()
    {
	    if (transform.position == checkpoints[checkpoints.Length - 1])
	    {
			gameManager.takeDamage(damage);
            Destroy(gameObject);
        }
    }

    /**
     *	Reduces health if the object is hit
     */
    public void takeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) die();
    }
    
    /**
     *	Moves the object towards the next checkpoint.
     *	If checkpoint is reached, switches the target to the next checkpoint
     */
	public void move()
	{
        if(transform.position == nextCheckpoint && transform.position != checkpoints[checkpoints.Length-1])
		{
            nextCheckpointIndex++;
            nextCheckpoint = checkpoints[nextCheckpointIndex];
		}
        transform.position = Vector3.MoveTowards(transform.position, nextCheckpoint, Time.deltaTime * speed);
	}
}
