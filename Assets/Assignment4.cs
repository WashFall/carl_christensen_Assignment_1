using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    private Vector2 char1, char2;
    private int diameter = 1;
    private float acc = 1.5f;
    private float speed = 5f;

    public void Start()
    {
        char1 = new Vector2(Width / 2, 6);
        char2 = new Vector2(Width / 2, 2);
    }

    public void Update()
    {
        Background(0);
        Circle(char1.x, char1.y, diameter);
        Circle(char2.x, char2.y, diameter);
        Move();
    }

    public void Move()
    {
        char1.x += speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        char1.y += speed * Input.GetAxis("Vertical") * Time.deltaTime;
        char2.x += speed * acc * Input.GetAxis("Horizontal") * Time.deltaTime;
        char2.y += speed * acc * Input.GetAxis("Vertical") * Time.deltaTime;
    }
}