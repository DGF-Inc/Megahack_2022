using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : Unit
{
	[SerializeField] private int level = 0;
	[SerializeField] private int maxLevel = 5;
	[SerializeField] private float attackSpeed = 1.5f;
	[SerializeField] private int damage = 10;
	[SerializeField] private int cost = 1100;
	[SerializeField] private WaveManager _waveManager;

	private void Start()
	{
		_waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
		StartCoroutine(attackWithDelay());
	}

	/**
	 *	Attacks the enemy given via the enemy argument
	 */
	public override void attack(GameObject enemy)
	{
		List<GameObject> gameObjects = _waveManager.getClosestList(gameObject.transform.position, range);
		foreach (var go in gameObjects)
		{
			enemy.GetComponent<Enemy>().takeDamage(damage);
		}
	}
	
	private IEnumerator attackWithDelay()
	{
		while (true)
		{
			List<GameObject> cl = _waveManager.getClosestList(gameObject.transform.position, range);

			foreach (var gameObject in cl)
			{
				attack(gameObject);
			}
			
			yield return new WaitForSeconds(attackSpeed);
		}
	}

	/**
	 *	Upgrades the Jellyfishes level
	 */
	public override void upgrade()
	{
		level++;
	}
}
