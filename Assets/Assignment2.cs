using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
        Background(Color.white);
        parabolic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int coordX = 1;
    int coordY = 10;

    void parabolic()
    {
        for(int i = 0; i < 11; i++)
        {
            Stroke(200, 200, 200);

            if(i % 3 == 2)
            {
                Stroke(0, 0, 0);
            }

            Line(0, coordY - i, coordX + i, 0);
        }
    }
}
