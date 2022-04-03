using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Game stats
    [SerializeField] private int money = 0;
    [SerializeField] private int health = 100;

    // Path data
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Vector3[] checkpoints;
    
    // Sound Sources
    [SerializeField] private AudioSource enemyHurtSoundSource;
    [SerializeField] private AudioSource baseHurtSoundSource;
    [SerializeField] private AudioSource placeSoundSource;

    public void Start()
    {
	    spawnPoint = checkpoints[0];
    }

    public void gainMoney(int moneyAdded)
    {
        money += moneyAdded;
    }
    
    // TODO: game over once health <= 0
    public void takeDamage(int damageTaken)
	{
		baseHurtSoundSource.Play();
		health -= damageTaken;

		if (health <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}


    public void playSoundEnemyHurt()
    {
	    enemyHurtSoundSource.Play();
    }

    public void playSoundPlace()
    {
	    placeSoundSource.Play();
    }
    

    /**
     *	Returns an array of checkpoints
     */
    public Vector3[] getCheckpoints()
    {
	    return checkpoints;
    }

    public int getHealth()
    {
	    return health;
    }

    public int getMoney()
    {
	    return money;
    }
}
