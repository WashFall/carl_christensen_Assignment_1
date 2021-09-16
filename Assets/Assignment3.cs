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
        Circle(circlePosition.x, circlePosition.y, diameter); //Spawns circle

        // When mousebutton is pressed down and held
        if (Input.GetMouseButton(0))
        {
            // Spawns Line between the circle and mouse position, and also saves some coordinates in vectors
            Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
            offset = new Vector2(MouseX - circlePosition.x, MouseY - circlePosition.y);
            destination = new Vector2(MouseX, MouseY);
            Debug.Log(circlePosition);
        }
        // The instance the mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Sets position of circle to position of mouse
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
        }
        // When mouse button is not pressed
        if (!Input.GetMouseButton(0))
        {
            movement(offset);
        }
    }

    // Calculates the magnitude(length) of the offset to the circle
    private void movement(Vector2 offset)
    {
        float length = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        float move = length * Time.deltaTime;

        // Moves the circle to the destination where mouse button was released
        if (circlePosition.x < Width - (diameter / 2) && circlePosition.y < Height - (diameter / 2) && circlePosition.x > diameter / 2 && circlePosition.y > diameter / 2)
        {
            circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
        }
        // This concerns bouncing of the edges on the x-axis
        else if(circlePosition.x >= Width - (diameter / 2) || circlePosition.x <= 2f)
        {
            if (offset.x > 0)
            {
                offset.x = destination.x - circlePosition.x;
                destination.x = Width - offset.x;
            }
            else if (offset.x < 0)
            {
                offset.x = destination.x - circlePosition.x;
                destination.x = -offset.x;
            }
            circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
        }
        // This concerns bouncing of the edges on the y-axis
        else if(circlePosition.y >= Height - (diameter / 2) || circlePosition.y <= 2f)
        {
            if (offset.y > 0)
            {
                offset.y = destination.y - circlePosition.y;
                destination.y = Height - offset.y;
            }
            else if(offset.y < 0)
            {
                offset.y = destination.y - circlePosition.y;
                destination.y = -offset.y;
            }
            circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
        }
    }
}
