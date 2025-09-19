using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

class TemporaryBody : StaticBody
{
    private int Lifetime;
    public int Reward;
    public TemporaryBody(Vector2 position, Texture2D texture, int lifetime, int reward, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
        Lifetime = lifetime;
        Reward = reward;
    }
    public void Grant(int Iscore, out int score)
    {
        score = Iscore + Reward;
    }
    public void die()
    {
    }
}