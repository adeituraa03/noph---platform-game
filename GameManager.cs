using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 0.3f;

    public GameObject completeLevelUI;

    public GameObject FallingUI;

    public GameObject restartUI;

    public GameObject coinUI;

    public void CompleteLevel()
    {
        //Debug.Log("Level won");
        completeLevelUI.SetActive(true);
    }

    public void CoinAnimation()
    {
        coinUI.SetActive(true);
    }


    public void RestartGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over!");
            Invoke("Restart", restartDelay);
            restartUI.SetActive(true);

        }

    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over!");
            Invoke("Restart", restartDelay);
            FallingUI.SetActive(true);

        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    
}
