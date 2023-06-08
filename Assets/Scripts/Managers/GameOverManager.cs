using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float restartDelay = 3f;

    private float restartTimer;
	private static bool gameOver;

	void Awake ()
	{
		gameOver = false;
	}

	void Update ()
	{
		if (gameOver)
		{
			GameOver();
        }
	}

    /// <summary>Show game over effects and restart application.</summary>
    private void GameOver()
	{
		anim.SetTrigger("GameOver");
		restartTimer += Time.deltaTime;

		if (restartTimer >= restartDelay)
		{
		    SceneManager.LoadScene(0);
		}
    }

    /// <summary>Set game over.</summary>
    public static void GameOver(bool state)
	{
		gameOver = state;
    }

}
