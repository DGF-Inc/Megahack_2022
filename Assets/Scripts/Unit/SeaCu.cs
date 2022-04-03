using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaCu : Unit
{
    // the buff damage multiplier 
    [SerializeField] private float damage = 1.1f;
    [SerializeField] private float attackSpeed = 5f;
    [SerializeField] private float buffDuration = 10f;
    [SerializeField] private int cost = 750;
    [SerializeField] private WaveManager _waveManager;

    private int level = 1;

    private void Start()
    {
        _waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
        StartCoroutine(attackWithDelay());
    }

    public override void upgrade()
    {
        level++;
    }

    private void Update()
    {
        Vector3 a_vec = gameObject.transform.position;
    }

    // this does not attack enemies but instead gives a damage buff to other Units
    public override void attack(GameObject target)
    {
        List<GameObject> gameObjects = _waveManager.getClosestFriends(gameObject.transform.position, range);
        foreach (var go in gameObjects)
        {
            go.GetComponent<Unit>().getBuffed(damage, buffDuration);
        }
        
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
    
    // prevent sea cucumbers from buffing each other
    public new void getBuffed(float multiplier, float duration)
    {
        return;
    }
}
