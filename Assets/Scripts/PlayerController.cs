using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    Rigidbody2D player;

    Vector2 movement;

    [SerializeField]
    float movementSpeed=1;

    //called once at start of game
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //get which key is pressed
        float input = Input.GetAxisRaw("Vertical");
        //finding velocity Vector of player with repect to key pressed
        movement = new Vector2(0, input).normalized * movementSpeed;
    }

    //called after every 60frames
    private void FixedUpdate()
    {
        //assigning velocity to player
        player.velocity = movement;
    }
}