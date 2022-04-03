using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    private int wave = 1;
    private int points = 250;
    private float wavePoints = 250;
    [SerializeField] private int trashCost = 20;
    [SerializeField] private int diverCost = 300;
    [SerializeField] private int boatCost = 800;
    [SerializeField] private int shipCost = 2000;

    [SerializeField] private GameObject trashPrefab;
    [SerializeField] private GameObject diverPrefab;
    [SerializeField] private GameObject boatPrefab;
    [SerializeField] private GameObject shipPrefab;

    [SerializeField] Vector3 spawnPoint;

    private List<GameObject> _enemies;
    private List<GameObject> _friends;

    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>();
        _friends = new List<GameObject>();
        StartCoroutine(spawnRandomEnemy());
    }

    private void Update()
    {
        _enemies.Clear();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var g in gameObjects)
        {
            _enemies.Add(g);
        }
        _friends.Clear();
        GameObject[] gameObjectFriends = GameObject.FindGameObjectsWithTag("Friend");
        foreach (var g in gameObjectFriends)
        {
            _friends.Add(g);
        }
    }

    public void delete(GameObject go)
    {
        _enemies.Remove(go);
    }

    public IEnumerator spawnRandomEnemy()
	{
        while (true)
        {
            if (points >= trashCost)
            {
                yield return new WaitForSeconds(0.33f);

                int rng = Random.Range(1, 100);
                switch (rng)
                {
                    case int i when (i >= 1 && i < 40):
                        points -= trashCost;
                        trashPrefab.GetComponent<Trash>().spawn(spawnPoint);
                        break;
                    case int i when (i >= 41 && i < 70):
                        if (points >= diverCost)
                        {
                            points -= diverCost;
                            diverPrefab.GetComponent<Diver>().spawn(spawnPoint);
                        }
                        break;
                    case int i when (i >= 71 && i < 90):
                        if (points >= boatCost)
                        {
                            points -= boatCost;
                            boatPrefab.GetComponent<Boat>().spawn(spawnPoint);
                        }
                        break;
                    case int i when (i >= 91 && i <= 100):
                        if (points >= shipCost)
                        {
                            points -= shipCost;
                            shipPrefab.GetComponent<Ship>().spawn(spawnPoint);
                        }
                        break;
                }
            }
            else
            {
                yield return new WaitForSeconds(5);
                wavePoints *= 1.3f;
                points = (int)wavePoints;
                wave++;
            }
        }
	}

    public int getCurrentWave()
    {
        return wave;
    }

    public GameObject getClosest(Vector3 pos, float range)
    {
        GameObject closest = null;
        float distance = 1000;
        foreach (var enemy in _enemies)
        {
            double tmp = Vector3.Distance(enemy.transform.position, pos);
            if (distance > tmp)
            {
                distance = (float) tmp;
                closest = enemy;
            }
        }
        if (distance > range) return null;
        return closest;
    }

    public List<GameObject> getClosestList(Vector3 pos, float range)
    {
        List<GameObject> closest = new List<GameObject>();
        foreach (var enemy in _enemies)
        {
            double tmp = Vector3.Distance(enemy.transform.position, pos);
            if (range > tmp)
            {
                closest.Add(enemy);
            }
        }
        return closest;
    }

    public List<GameObject> getClosestFriends(Vector3 pos, float range)
    {
        List<GameObject> closest = new List<GameObject>();
        foreach (var friend in _friends)
        {
            double tmp = Vector3.Distance(friend.transform.position, pos);
            if (range > tmp)
            {
                closest.Add(friend);
            }
        }
        return closest; 
    }
}
