using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
namespace BombermanNEA;

public class Timer
{
    public int delay { get; private set; }
    public Timer(int delay)
    {
        this.delay = delay;
    }
    public void Start(out bool Switch)
    {
        Thread.Sleep(delay);
        Switch = false;
    }
}