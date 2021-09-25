using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    int ballcount = 10;
    float playerSize = 1f;
    float ballSize = 0.75f;
    Player player;
    Ball[] balls;

    public void Start()
    {
        player = new Player(Width / 2, Height / 2);
        balls = new Ball[ballcount];
        for (int i = 0; i < balls.Length; i++)
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
            player.CircleCollision(player.position.x, player.position.y, playerSize,
                ball.position.x, ball.position.y, ballSize);
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
    public Vector2 position;

    public Player(float x, float y)
    {
        position = new Vector2(x, y);
    }

    public void Draw()
    {
        Fill(255);
        Circle(position.x, position.y, diameter);
    }

    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 + size2;

        if(Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        else if(Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        else
        {
            Debug.Log("Works");
            return true;
        }
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
    public Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    float ballDiameter = 0.75f; //Diameter of ball
    float ballRadius = 0.375f; //Radius of ball

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
        Circle(position.x, position.y, ballDiameter);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        //Change direction at edge of screen width
        if (position.x > Width - ballRadius || position.x < ballRadius)
        {
            velocity.x *= -1;
        }

        //Change direction at edge of screen height
        if (position.y > Height - ballRadius || position.y < ballRadius)
        {
            velocity.y *= -1;
        }
    }
}
