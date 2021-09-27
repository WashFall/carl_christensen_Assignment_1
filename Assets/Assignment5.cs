using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    BallManager manager = new BallManager();
    public Player player;
    public GameObject gameOver;

    public void Start()
    {
        Application.targetFrameRate = 300;
        player = new Player(Width / 2, Height / 2);
        manager.BallCall();
    }

    public void Update()
    {
        Background(0);
        player.Move();
        player.Draw();
        manager.NewBall();
        manager.BallDraw(player, gameOver);
    }
}

public class Player : ProcessingLite.GP21
{
    private int diameter = 1;
    private float radius = 0.5f;
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

    public bool CircleCollision(Ball ball)
    {
        float maxDistance = radius + ball.ballRadius;

        if(Mathf.Abs(position.x - ball.position.x) > maxDistance 
            || 
           Mathf.Abs(position.y - ball.position.y) > maxDistance)
        {
            return false;
        }
        else if(Vector2.Distance(new Vector2(position.x, position.y), 
                new Vector2(ball.position.x, ball.position.y)) > maxDistance)
        {
            return false;
        }
        else
        {
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

public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    float ballDiameter = 0.5f; //Diameter of ball
    public float ballRadius = 0.25f; //Radius of ball

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

public class BallManager : ProcessingLite.GP21
{
    Ball[] balls;
    int ballcount = 100;
    int arrayPosition = 10;
    int framecount = 0;

    public void BallCall()
    {
        balls = new Ball[ballcount];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(3, 3);
        }
    }

    public void BallDraw(Player player, GameObject gameOver)
    {
        for(int i = 0; i < arrayPosition; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
            player.CircleCollision(balls[i]);

            if (player.CircleCollision(balls[i]) == true)
            {
                gameOver.SetActive(true);
            }
        }

    }

    public void NewBall()
    {
        framecount++;

        if(framecount == 900 && arrayPosition < 100)
        {
            arrayPosition++;
            framecount = 0;
        }
    }
}
