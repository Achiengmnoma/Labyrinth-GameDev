using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //allows playerM to interact and respond to collisions
    private Rigidbody2D playerM;

    //controls the player animation to the opposite direction
    private SpriteRenderer leftM;

    //speed of the player/character
    float playerSpeed = 20f;
    void Start()
    {
        //allows access of playerM
        playerM = GetComponent<Rigidbody2D>();

        leftM = GetComponent<SpriteRenderer>();
    }

    public enum ControlMethod
    {
        Keyboard,
        Mouse
    }

    private ControlMethod chosenControlMethod = ControlMethod.Keyboard;
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Horizontal"))
        // {
        //     playerM.velocity = new Vector3(14f, 0, 0);
        // }
        // else if (Input.GetButtonDown("Vertical"))
        // {
        //     playerM.velocity = new Vector3(0, 14f, 0);
        // }

        if (chosenControlMethod == ControlMethod.Keyboard)
        {
            float moveAcross = Input.GetAxis("Horizontal");
            if (moveAcross > 0f)
            {
                leftM.flipX = false;
            }
            else if (moveAcross < 0f)
            {
                leftM.flipX = true;
            }

            float moveVertical = Input.GetAxis("Vertical");
            //direction in which the player moves
            Vector2 playerMovement = new Vector2(moveAcross, moveVertical);
            //sets the velocity of the player
            playerM.velocity = playerMovement.normalized * playerSpeed;
        }
        else
        {

            // Handle mouse input for character movement
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, playerSpeed * Time.deltaTime);

            Vector3 direction = mousePosition - transform.position;
            if (direction.x > 0f)
            {
                // Mouse cursor is to the right of the player
                transform.localScale = new Vector3(1, 1, 1); // Face right
            }
            else if (direction.x < 0f)
            {
                // Mouse cursor is to the left of the player
                transform.localScale = new Vector3(-1, 1, 1); // Face left
            }
        }

        //check if player switches control using return key
        //|| Input.GetKey(KeyCode.LeftShift)
        if (Input.GetKeyDown(KeyCode.RightShift)) // Using the Space key to toggle control method
        {
            // Toggle between control methods
            chosenControlMethod = (chosenControlMethod == ControlMethod.Keyboard) ? ControlMethod.Mouse : ControlMethod.Keyboard;
        }















        // //For mouse movements
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // transform.position = Vector2.MoveTowards(transform.position,mousePosition,playerSpeed * Time.deltaTime);

        // Input.GetMouseButtonDown(0);//0 left 1 for right
        // //allows character to move based on the choosen axis
        // float moveAcross = Input.GetAxis("Horizontal");
        // if(moveAcross > 0f){
        //     leftM.flipX = false;
        // }else if(moveAcross < 0f){
        //     leftM.flipX = true;
        // }

        // float moveVertical = Input.GetAxis("Vertical");
        // //direction in which the player moves
        // Vector2 playerMovement = new Vector2(moveAcross, moveVertical);
        // //sets the velocity of the player
        // playerM.velocity = playerMovement.normalized * playerSpeed;
    }
}
