using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

class Guard : Enemy
{
    public Guard(Vector2 position, Texture2D texture, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
        Durability = 20;
        PointsOnDeath = 30;
    }
}