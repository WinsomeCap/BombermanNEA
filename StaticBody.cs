using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

class StaticBody : PhysicsBody //a non-moving object in the game world
{
    public StaticBody(Vector2 position, Texture2D texture, float layerDepth, Color? color = null)
        : base(position, texture, layerDepth, color)
    {
    }
}