using UnityEngine;

public class WalkerTest : ProcessingLite.GP21
{
    IRandomWalker walker;
    Vector2 walkerPos;
    float scaleFactor = 0.05f;

    void Start()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;

        walker = new CarChr();

        walkerPos = walker.GetStartPosition((int)(Width / scaleFactor), (int)(Height / scaleFactor));
    }

    void Update()
    {
        Point(walkerPos.x * scaleFactor, walkerPos.y * scaleFactor);

        walkerPos += walker.Movement();
    }
}
