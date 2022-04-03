using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Unit
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackSpeed = 3f;
    [SerializeField] private int cost = 1200;
    [SerializeField] private WaveManager _waveManager;

    private int level = 1;

    private void Start()
    {
        _waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
        StartCoroutine(attackWithDelay());
    }

    private void Update()
    {
        
    }

    public override void upgrade()
    {
        level++;
    }
    
    private IEnumerator attackWithDelay()
    {
        while (true)
        {
            GameObject cl = _waveManager.getClosest(gameObject.transform.position, range);
            if (cl != null)
            {
                attack(cl);
            }
			
            yield return new WaitForSeconds(attackSpeed);
        }
    }
    
    public override void attack(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().takeDamage(damage);
    }
}
