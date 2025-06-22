using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

class GameObject : RenderableObject
{
    public Vector2 RelativeAnchor { get; set; }
    public Vector2 RelativePosition { get; set; }
    public GameObject(Vector2 position, Texture2D texture, float layerDepth, Color? color = null)
        : base(position, texture, layerDepth, color)
    {
        
    }
}