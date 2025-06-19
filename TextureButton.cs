using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

class TextureButton : Control
{

    public TextureButton(Theme theme, Vector2 position, Texture2D texture, string text, float size = 1, Color? canvasModulate = null)
        : base(theme, position, texture, size, canvasModulate) { }
    public virtual void Click()
    {
        // Handle button click logic here
        // For example, you could change the texture or trigger an event
        // This method can be overridden in derived classes/instances for custom behavior
    }
}