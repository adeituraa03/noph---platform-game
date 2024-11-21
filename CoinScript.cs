using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinScript : MonoBehaviour
{
    public AudioClip CoinSoundEffect;//creates a public variable to hold the coin sound effect

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);//this rotates the coins along the z axis
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))//if the collsion happens with a gameobject with the "player" tag
        {
            AudioSource.PlayClipAtPoint(CoinSoundEffect, transform.position);//adding Camera.main doesnt allow the sound to be made
            collision.GetComponent<PointCounter>().Coins++;//when the player collides with the coin it will add 1 to the coin variable 
            //FindObjectOfType<GameManager>().CoinAnimation();
            Destroy(gameObject);//once the player collides with the coin it destroys the coin - to look as if the player has collected the coin


        }
    }
}
