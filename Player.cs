using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

class Player : KinematicBody
{
    protected int PointsOnDeath;
    protected int Durability;
    public Player(Vector2 position, Texture2D texture, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
    }
    public virtual void OnDeath()
    {
    }
}