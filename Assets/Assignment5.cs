using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    private float acc = 5f;
    private float speed = 3f;
    private float maxSpeed = 10f;

    private Vector2 char1;
    private Vector2 input;

    Player player = new Player();
    Ball ball;

    public void Start()
    {
        char1 = new Vector2(Width / 2, Height / 2);

    }

    public void Update()
    {
        Background(0);
        Move();
        player.Draw(char1);
        ball = new Ball(5, 3);
        ball.Draw();
        ball.UpdatePos();

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

public class Player : ProcessingLite.GP21
{
    private int diameter = 1;

    public void Draw(Vector2 char1)
    {
        Fill(255);
        Circle(char1.x, char1.y, diameter);
    }
}

class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    //Draw our ball
    public void Draw()
    {
        Fill(0, 255, 125);
        Circle(position.x, position.y, 1);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

    }
}
