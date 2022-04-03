using System;
using System.Collections;
using UnityEngine;

/**
 *  Parent class of all units
 */
public abstract class Unit : MonoBehaviour
{
    /**
     *  Declaration of the Units basic values
     */
    public int level;
    public int maxLevel;
    public float attackSpeed;
    public float baseDamage;
    public float damage;
    public int cost;
    public float range;
    
    /**
     *  Level-Up
     */
    public abstract void upgrade();
    
    /**
     *  Attacks a given target
     */
    public abstract void attack(GameObject target);
    
    /**
     *  Spawns a new instance to a given position
     */
    public void spawn(Vector3 position)
    {
        Instantiate(gameObject, position, Quaternion.identity);
    }
    
    /**
     *  Starts the buff
     */
    public void getBuffed(float multiplier, float duration)
    {
        StartCoroutine(buff(multiplier, duration));
    }
    
    /**
     *  Multiplies the objects damage with a given multiplier
     *  (in case of SeaCus, nothing happens)
     *  The duration of the buff is given by the duration argument
     */
    private IEnumerator buff(float multiplier, float duration)
    {
        float originalDamage = damage;
        damage *= multiplier;
        yield return new WaitForSeconds(duration);
        damage = originalDamage;
    }

    public int getCost()
    {
       return cost;
    }
}
