using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

public class GameObject : RenderableObject
{
    public Color color { get; set; } = Color.White; // Default color is white
    public Vector2 RelativeAnchor { get; set; }
    public Vector2 RelativePosition { get; set; }
    public GameObject(Vector2 position, Texture2D texture, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
        this.color = color ?? Color.White; // Use the provided color or default to white
    }
}