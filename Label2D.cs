using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BombermanNEA
{
    public class Label2D : Control
    {
        public string Text { get; set; }
        public int Alignment { get; set; } = 0; // 0: Left, 1: Center, 2: Right

        public Label2D(Theme theme, Vector2 position, Texture2D texture, string text, int alignment, float size = 1, Color? canvasModulate = null)
            : base(theme, position, texture, size, canvasModulate)
        {
            Text = text;
            Alignment = alignment;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Theme.Font != null && !string.IsNullOrEmpty(Text))
            {
                Vector2 textSize = Theme.Font.MeasureString(Text) * Size;
                Vector2 textPosition = Position;// + new Vector2((spriteBatch.GraphicsDevice.Viewport.Width - textSize.X) / 2, (spriteBatch.GraphicsDevice.Viewport.Height - textSize.Y) / 2);
                spriteBatch.DrawString(Theme.Font, Text, textPosition, Theme.TextColor * CanvasModulate, 0f, Vector2.Zero, Size, SpriteEffects.None, 0f);
            }
            base.Draw(spriteBatch);
        }
    }
}