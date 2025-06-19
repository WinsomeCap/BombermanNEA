using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

public class Control : RenderableObject
{
    public Control(Theme theme, Vector2 position, Texture2D texture, float size = 1, Color? canvasModulate = null) : base(position, texture, size, canvasModulate)
    {
        Theme = theme;
    }
    public static Theme Theme { get; set; } = new Theme("Default", Color.Black, Color.White, Color.Gray, Color.LightGray, null, 12);
}