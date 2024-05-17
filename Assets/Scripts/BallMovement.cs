using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallMovement : MonoBehaviour
{

    [SerializeField]
    float startSpeed, extraSpeed, maxExtraSpeed,hitCounter;

    Rigidbody2D ball;

    [SerializeField]
    TMP_Text playerScore, cpuScore,displayText;

    [SerializeField]
    GameObject restartBTN;

    int player, cpu;

    // Start is called before the first frame update
    void Start()
    {
        player = 0;
        cpu = 0;
        ball = this.GetComponent<Rigidbody2D>();
        StartCoroutine(launch());
    }


    //Launch Ball towards Player
    IEnumerator launch() {
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        moveBall(new Vector2(1, Random.Range(-1f, 1f)));
    }


    //Add velocity to ball in recieved direction
    void moveBall(Vector2 direction) {
        float ballSpeed = startSpeed + extraSpeed * hitCounter;
        ball.velocity = direction * ballSpeed;
        if (extraSpeed * hitCounter < maxExtraSpeed)
        {
            hitCounter++;
        }
    }


    //Called when ball collides with any Object
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //finding ball position on collision
        Vector2 ballPosition = this.transform.position;

        //finding colider position on collision
        Vector2 colliderPosition = collision.transform.position;

        //get height of collider
        float colliderHeight = collision.collider.bounds.size.y;

        //finding position where ball should reflect on Y axis
        float positionY = (ballPosition.y - colliderPosition.y) / colliderHeight;

        //reflect ball
        if (collision.gameObject.tag == "Player")
        {
            moveBall(new Vector2(-1, positionY));
        }
        else if(collision.gameObject.tag == "Cpu") {
            moveBall(new Vector2(1, positionY));
        }

        //increase score if ball colliders left or right borders
        else if (collision.gameObject.tag == "LeftBorder")
        {
            player++;
            playerScore.text = player.ToString();
            ball.velocity = Vector2.zero;
            ball.transform.position=Vector2.zero;
            StartCoroutine(launch());
            //checking if player won
            if (player == 10) {
                restartBTN.SetActive(true);
                displayText.text = "Player Won";
            }
        }
        else if (collision.gameObject.tag == "RightBorder"){
            cpu++;
            cpuScore.text = cpu.ToString();
            ball.velocity = Vector2.zero;
            ball.transform.position = Vector2.zero;
            StartCoroutine(launch());
            //checking if cpu won
            if (cpu == 10)
            {
                restartBTN.SetActive(true);
                displayText.text = "Cpu Won";
            }
        }
    }


    //Called when RestartBTN Pressed
    public void restart() {
        //Reload Scene
        SceneManager.LoadScene("Main");
    }
}
