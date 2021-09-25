using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    private Vector2 char1;
    private int diameter = 1;
    private float acc = 5f;
    private float speed = 3f;
    private float maxSpeed = 10f;
    private Vector2 input;

    public void Start()
    {
        char1 = new Vector2(Width / 2, Height / 2);
    }

    public void Update()
    {
        Background(0);
        Circle(char1.x, char1.y, diameter);
        Move();
    }

    public void Move()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude != 0)
        {
            char1.x += speed * Input.GetAxis("Horizontal") * Time.deltaTime;
            char1.y += speed * Input.GetAxis("Vertical") * Time.deltaTime;


            if (speed < maxSpeed)
            {
                speed += acc * Time.deltaTime;
            }


        }
        else if (input.magnitude == 0)
        {
            speed = 3f;
        }
    }
}