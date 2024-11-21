using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{

    public int Coins = 0;

    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LostCoins()
    {
        Coins -= 1;
        Debug.Log(Coins);
    }

    private void OnGUI()
    {
        coinText.text = Coins.ToString();

    }

    //if player colletcs certain amount of coins give badge grade thing like fireboy and water girl
}
