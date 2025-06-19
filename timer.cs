using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

public class Timer
{
    public int delay { get; private set; }
    public Timer(int delay)
    {
        this.delay = delay;
    }
    public bool Start(GameTime gt)
    {
        int Milliseconds = (int)gt.ElapsedGameTime.TotalMilliseconds;
        int initMilliseconds = Milliseconds;
        while (Milliseconds < initMilliseconds + delay)
        {
            Milliseconds += (int)gt.ElapsedGameTime.TotalMilliseconds;
        }
        return true;
    }
}