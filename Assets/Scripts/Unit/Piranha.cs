using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : Unit
{
    [SerializeField] private int level = 0;
    [SerializeField] private int maxLevel = 5;
    [SerializeField] private float attackSpeed = 2;
    [SerializeField] private int damage = 5;
    [SerializeField] private int cost = 200;
    [SerializeField] private WaveManager wavemanager;
    [SerializeField] private new float range = 5f;

	private void Start()
	{
		wavemanager = GameObject.Find("GameManager").GetComponent<WaveManager>();
		StartCoroutine(attackWithDelay());
	}

    override public void attack(GameObject enemy)
	{
		enemy.GetComponent<Enemy>().takeDamage(damage);
	}

    private IEnumerator attackWithDelay()
	{
		while (true)
		{
			GameObject cl = wavemanager.getClosest(gameObject.transform.position, range);
			if (cl != null)
			{
				attack(cl);
			}
			
			yield return new WaitForSeconds(attackSpeed);
		}
	}
    
	override public void upgrade()
	{
        level++;
	}
}
