using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Lifespan : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animation;

    //controls player death dissapear
    private Rigidbody2D die;



    //Synchronize action with sound
    [SerializeField] private AudioSource deathSoundEffect;

    //TIMER
    public float timeleft;
    public bool timeon = false;
    public Text timerText;

    void Start()
    {
       // timeleft = 10;
        timeon = true;
        animation = GetComponent<Animator>();
        die = GetComponent<Rigidbody2D>();
        //Debug.Log("start");

    }

    void Update()
    {
        if (timeon)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                updateTimer(timeleft);
            }
            else{

                timeleft = 0;
                timeon = false;
                Debug.Log("time is up");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //moves to the next screen when time is up but i will change
                restartScreen();
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Death();
        }
    }
    //freezes the game object by the setting Static, which stops any game interaction
    private void Death()
    {
        deathSoundEffect.Play();
        die.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("death");
    }
    //reloads the screen/reloads the level
    private void restartScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
