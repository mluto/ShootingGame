using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] public int currentHealth;

	void Awake ()
	{
		currentHealth = startingHealth;
	}

    /// <summary>Get damage when attacked</summary>
    /// <param name="amount">Amount of health to loss by attack</param>
    public void GetDamage (int amount)
	{
		if (currentHealth > 0)
		{
			currentHealth -= amount;
            HealthBar.HealthLoss(currentHealth);
        }

		if (currentHealth <= 0)
		{
			GameOverManager.GameOver(true);
        }
	}

}