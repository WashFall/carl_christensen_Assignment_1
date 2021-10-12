using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    public Vector2 circlePosition;

    private float diameter = 2;
    private Vector2 offset;
    private Vector2 destination;

    void Start()
    {

    }

    void Update()
    {
        Background(Color.black);
        Circle(circlePosition.x, circlePosition.y, diameter); //Spawns circle

        if (Input.GetMouseButton(0))
        {
            // Spawns Line between the circle and mouse position
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
            Movement(offset);
        }
    }

    private void Movement(Vector2 offset)
    {
        float length = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        float move = length * Time.deltaTime;

        // If the circle moves outside the borders it teleports
        if (circlePosition.x < 1)
        {
            circlePosition.x = 0 + (diameter / 2);
        }
        else if (circlePosition.x > Width - (diameter / 2))
        {
            circlePosition.x = Width - (diameter / 2);
        }

        if (circlePosition.y < 1)
        {
            circlePosition.y = 0 + (diameter / 2);
        }
        else if (circlePosition.y > Height - (diameter / 2))
        {
            circlePosition.y = Height - (diameter / 2);
        }

        // Moves the circle to the destination where mouse button was released
        if (circlePosition.x < Width - (diameter / 2)
            && circlePosition.y < Height - (diameter / 2)
            && circlePosition.x > diameter / 2
            && circlePosition.y > diameter / 2)
        {
            circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
        }

        // This concerns bouncing of the edges on the x-axis
        else if (circlePosition.x >= Width - (diameter / 2) || circlePosition.x <= 1f)
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
        else if (circlePosition.y >= Height - (diameter / 2) || circlePosition.y <= 1f)
        {
            if (offset.y > 0)
            {
                offset.y = destination.y - circlePosition.y;
                destination.y = Height - offset.y;
            }
            else if (offset.y < 0)
            {
                offset.y = destination.y - circlePosition.y;
                destination.y = -offset.y;
            }
            circlePosition = Vector2.MoveTowards(circlePosition, destination, move);
        }
    }
}
