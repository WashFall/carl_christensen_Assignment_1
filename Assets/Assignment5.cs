using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    Player player;
    int ballcount = 10;
    Ball[] balls;

    public void Start()
    {
        player = new Player(Width / 2, Height / 2);
        balls = new Ball[ballcount];
        for(int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(3, 3);
        }
    }

    public void Update()
    {
        Background(0);
        player.Move();
        player.Draw();
        foreach (Ball ball in balls)
        {
            ball.UpdatePos();
            ball.Draw();
        }
    }


}

public class Player : ProcessingLite.GP21
{
    private int diameter = 1;
    private float speed = 3f;
    private float maxSpeed = 10f;
    private float acc = 5f;

    private Vector2 input;
    private Vector2 position;
    public Player(float x, float y)
    {
        position = new Vector2(x, y);
    }
    public void Draw()
    {
        Fill(255);
        Circle(position.x, position.y, diameter);
    }

    public void Move()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude != 0)
        {
            position.x += speed * Input.GetAxis("Horizontal") * Time.deltaTime;
            position.y += speed * Input.GetAxis("Vertical") * Time.deltaTime;

            if (speed < maxSpeed)
            {
                speed += acc * Time.deltaTime;
            }


        }
        else if (input.magnitude == 0)
        {
            speed = 3f;
        }
        position = new Vector2(position.x, position.y);
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
        velocity.x = Random.Range(0f, 11f) - 5;
        velocity.y = Random.Range(0f, 11f) - 5;
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
        if(position.x > Width - 0.5f || position.x < 0.5f)
        {
            velocity.x *= -1;
        }
        if(position.y > Height - 0.5f || position.y < 0.5f)
        {
            velocity.y *= -1;
        }
    }
}
