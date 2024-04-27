using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ItemCollector : MonoBehaviour
{
    // Start is called before the first frame update
    //initializes the values of the scores
    private int Watermelon = 0;
    private int Coins = 0;
    private int totalScore = 0;

   
    //plays when everthing is connected
    private AudioSource completeLevel;

    //Stores the values and retrieves them when saving or loading scenes.
    [SerializeField] private Text fruitText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text totalText;


    //private int totMelons;
   private int totCoins;

    //Synchronise action with sound
    [SerializeField] private AudioSource coinCollectionSound;

    [SerializeField] private AudioSource fruitCollectionSound;

    private void Start(){
        completeLevel  = GetComponent<AudioSource>();

        // totMelons = GameObject.FindGameObjectsWithTag("Watermelon").Length;
        //totCoins = GameObject.FindGameObjectsWithTag("Coins").Length;
        //totMelons = 0;
       //totCoins = 50;
    }

    //called when a 2D collider triggers a collision with another collider set to trigger mode.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The if conditions they destroy and update the UI text of their specific game object tags, while increasing the counter based on the assigned values
        if (collision.gameObject.CompareTag("Watermelon"))
            {   
                //plays when fruits are collected
                fruitCollectionSound.Play();
                Destroy(collision.gameObject);
                Watermelon += 25;
                //Watermelon++;
                fruitText.text = "Cherries : " + Watermelon;
                Debug.Log("Watermelon: " + Watermelon);

            }
        if (collision.gameObject.CompareTag("Coins"))
        {
            //plays when coins are picked
            coinCollectionSound.Play();
            Destroy(collision.gameObject);
            Coins += 50;
            //Coins++
            coinsText.text = "Coins : " + Coins;
            
            Debug.Log("Coins collected = " + Coins);
        
            Debug.Log("coins reamian :"+ Coins);

        }


        totalScore = Coins + Watermelon;
        //Savedata();
        totalText.text = "Total Score : " + totalScore;

        if(totalScore == 900 && totalScore < 1675)
        {
            SceneManager.LoadScene("Level 2");
        }else if(totalScore == 1675){
            SceneManager.LoadScene("End Screen");
        }
        
    }
        //          if (Coins == totCoins)
   public void Savedata(){
        
        
    PlayerPrefs.SetInt("TotalScore", totalScore);
    PlayerPrefs.Save();
    SceneManager.LoadScene("End Screen");



    }
    

}
