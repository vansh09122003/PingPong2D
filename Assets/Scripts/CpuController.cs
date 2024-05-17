using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuController : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D ball,cpu;

    // Update is called once per frame
    void Update()
    {
        //add velocity to cpu in y axis
        cpu.velocity = new Vector2(0, ball.velocity.y);
    }
}
