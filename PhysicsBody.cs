using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

class PhysicsBody : GameObject
{
    public PhysicsBody(Vector2 position, Texture2D texture, float layerDepth, Color? color = null)
        : base(position, texture, layerDepth, color)
    {
        
    }

}