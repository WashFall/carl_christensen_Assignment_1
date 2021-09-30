using UnityEngine;

class CarChr : IRandomWalker
{
    public int width;
    public int height;
    public Vector2 walkerPos;

    public string GetName()
    {
        return "Carl C";
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        width = playAreaWidth;
        height = playAreaHeight;

        walkerPos.x = Random.Range(1, playAreaWidth);
        walkerPos.y = Random.Range(1, playAreaHeight);

        return new Vector2(walkerPos.x, walkerPos.y);
    }

    public Vector2 Movement()
    {
        //if (walkerPos.x == width - 1)
        //    walkerPos.x += -1;
        //else if (walkerPos.x == 1)
        //    walkerPos.x += 1;
        //else if (walkerPos.y == height - 1)
        //    walkerPos.y += -1;
        //else if (walkerPos.y == 1)
        //    walkerPos.y += 1;



        switch (Random.Range(0, 4))
        {
            case 0:
                walkerPos.x += -1;
                if (walkerPos.x == 1)
                {
                    walkerPos.x += 2;
                    return new Vector2(1, 0);
                }
                else
                    return new Vector2(-1, 0);
            case 1:
                walkerPos.x += 1; 
                if (walkerPos.x == width - 1)
                {
                    walkerPos.x += -2;
                    return new Vector2(-1, 0);
                }
                else
                    return new Vector2(1, 0);
            case 2:
                walkerPos.y += 1;
                if (walkerPos.y == height - 1)
                {
                    walkerPos.y += -2;
                    return new Vector2(0, -1);
                }
                else
                    return new Vector2(0, 1);
            default:
                walkerPos.y += -1;
                if (walkerPos.y == 1)
                {
                    walkerPos.y += 2;
                    return new Vector2(0, 1);
                }
                else
                    return new Vector2(0, -1);
        }
    }
}
