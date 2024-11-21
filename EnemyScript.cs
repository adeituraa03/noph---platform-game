using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public float Distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, Enemy.transform.position);
        if(Distance < 7)
        {
            Distance = Distance - 5;
            Debug.Log(Distance);//player.position = distance
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit mushroom");
            Destroy(gameObject);
            FindObjectOfType<LivesScript>().Damage();
            FindObjectOfType<PointCounter>().LostCoins();
        }
    }
}
