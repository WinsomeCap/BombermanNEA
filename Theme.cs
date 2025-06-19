using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BombermanNEA;

public class Theme
{
    public string Name { get; set; }
    public Color BackgroundColor { get; set; }
    public Color TextColor { get; set; }
    public Color ButtonColor { get; set; }
    public Color ButtonTextColor { get; set; }
    public SpriteFont Font { get; set; }
    public int TextSize { get; set; } = 12; // Default text size

    public Theme(string name, Color backgroundColor, Color textColor, Color buttonColor, Color buttonTextColor, SpriteFont font, int textSize)
    {
        Name = name;
        BackgroundColor = backgroundColor;
        TextColor = textColor;
        ButtonColor = buttonColor;
        ButtonTextColor = buttonTextColor;
        Font = font;
        TextSize = textSize;
    }

    public override string ToString()
    {
        return $"{Name} Theme: Background={BackgroundColor}, Text={TextColor}, Button={ButtonColor}, ButtonText={ButtonTextColor}, Font={Font.ToString()}, TextSize={TextSize}";
    }
}