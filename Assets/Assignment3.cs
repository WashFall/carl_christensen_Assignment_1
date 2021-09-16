using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector2 circlePosition;
    private float diameter = 2;
    private Vector2 offset;
    private Vector2 destination;

    // Update is called once per frame
    void Update()
    {
        Background(Color.black);
        Circle(circlePosition.x, circlePosition.y, diameter);

        if (Input.GetMouseButton(0))
        {
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
            offset = new Vector2(MouseX - circlePosition.x, MouseY - circlePosition.y);
            destination = new Vector2(MouseX, MouseY);
            Debug.Log(circlePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
        }
        if (!Input.GetMouseButton(0))
        {
            movement(offset);
        }
        


    }

    private void movement(Vector2 offset)
    {
        float length = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        float move = length * Time.deltaTime;

        circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
    }

}
