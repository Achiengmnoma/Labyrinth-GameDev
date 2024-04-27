using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource gameoverSound;
    private void Start()
    {
        gameoverSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

        //detects if we are collidng with the player inorder to finish the level and load the next one
        if(collision.gameObject.name == "Player"){
            gameoverSound.Play();
            finishLevel();
        }
    }

    private void finishLevel(){

    }

   
}
