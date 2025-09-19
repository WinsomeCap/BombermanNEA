using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA;

public class TextButton : Control
{
    public Label2D Label { get; set; }

    public TextButton(Theme theme, Vector2 position, Label2D label, float size = 1, Color? canvasModulate = null)
        : base(theme, position, null, size, canvasModulate)
    {
        Label = label;
    }

    public virtual void Click()
    {
        // Handle button click logic here
        // This method can be overridden in derived classes/instances for custom behavior
    }
}