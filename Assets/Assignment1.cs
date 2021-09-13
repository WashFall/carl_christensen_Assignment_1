using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    private int timer = 0; // A variable to keep track of every 100 passed frames

    // Start is called before the first frame update
    void Start()
    {
        Background(Color.black);
        StrokeWeight(2);
        // Changes the background color, and width of the stroke for the letters
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        Shapes();
        LetterC();
        LetterA();
        LetterR();
        LetterL();
        // Adds to the timer variables and calls the functions for all the letters and the background shapes
    }

    private void LetterC()
    {
        BeginShape();
        Vertex(4, 2);
        Vertex(4, 1);
        Vertex(1, 1);
        Vertex(1, 7);
        Vertex(4, 7);
        Vertex(4, 6);
        EndShape();
        // Creates the letter 'C'
    }

    private void LetterA()
    {
        BeginShape();
        Vertex(6, 1);
        Vertex(6, 7);
        Vertex(9, 7);
        Vertex(9, 1);
        EndShape();
        Line(6, 4, 9, 4);
        // Creates the letter 'A'
    }

    private void LetterR()
    {
        BeginShape();
        Vertex(11, 1);
        Vertex(11, 7);
        Vertex(14, 7);
        Vertex(14, 4);
        Vertex(11, 4);
        Vertex(14, 1);
        EndShape();
        // Creates the letter 'R'
    }

    private void LetterL()
    {
        BeginShape();
        Vertex(16, 7);
        Vertex(16, 1);
        Vertex(19, 1);
        EndShape();
        // Creates the letter 'L'
    }

    private void Shapes() // This function creates the colorful shapes in the background
    {
        if (timer == 100)
        {
            NoStroke();
            var corner1 = new Vector2(Random.Range(0f, 21.21f), Random.Range(0f, 10f)); // I make a lot of randomized coordinates
            var corner2 = new Vector2(Random.Range(0f, 21.21f), Random.Range(0f, 10f));
            var corner3 = new Vector2(Random.Range(0f, 21.21f), Random.Range(0f, 10f));
            var corner4 = new Vector2(Random.Range(0f, 21.21f), Random.Range(0f, 10f));

            var color = new Vector3Int(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)); // This is for random colors

            Fill(color.x, color.y, color.z); // I change the fill color every time the function is called

            Quad(corner1.x, corner1.y, corner2.x, corner2.y, corner3.x, corner3.y, corner4.x, corner4.y);
            // I create a shape with randomized coordinates, and with a new random color every 100 frames
            
            timer = 0;
            Stroke(255, 255, 255); // Resetting som settings to their original states
        }
    }
}