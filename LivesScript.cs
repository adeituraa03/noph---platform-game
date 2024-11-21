using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{

    public int totalLives = 3;

    public TextMeshProUGUI livesText;


    // Start is called before the first frame update
    void Start()
    {
        //currentLives = totalLives;
    }


    public void Damage()
    {
        totalLives -= 1;
        Debug.Log(totalLives);
        //currentLives += 1;
        //Debug.Log(currentLives);

        if(totalLives <= 0)
        {
            FindObjectOfType<GameManager>().RestartGame();
        }
    }

    private void OnGUI()
    {
        livesText.text = totalLives.ToString();
    }


}
