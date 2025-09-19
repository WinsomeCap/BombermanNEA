using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

class Enemy : KinematicBody
{
    TemporaryBody colls;
    protected int PointsOnDeath = 0;
    protected int Durability = 0;
    public Enemy(Vector2 position, Texture2D texture, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
    }
    public virtual void OnDeath()
    {
    }
    public virtual void Attack()
    {
    }
    public virtual void Movement()
    {
    }

}