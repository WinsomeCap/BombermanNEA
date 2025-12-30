using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class RenderableObject
{
    // Base class for renderable objects in the game
    // Contains properties for position, texture, and color modulation
    // Can be extended for specific game objects like players, enemies, etc.
    // Provides a Draw method to render the object using a SpriteBatch (handled by Monogame)
    // The Draw method can be overridden in derived classes for custom rendering behavior
    public static List<RenderableObject> RenderableObjects { get; internal set; } = new List<RenderableObject>();
    // List of RenderableObjects to the class so that we can keep track of all renderable objects in the game, and update the list when new objects are added or removed.

    public Vector2 Position { get; set; }
    public Texture2D Texture { get; set; }
    public Color CanvasModulate { get; set; } = Color.White;
    public float Size { get; set; } = 1.0f; // Default size is 1.0f

    public RenderableObject(Vector2 position, Texture2D texture, float size = 1.0f, Color? canvasModulate = null)
    {
        Position = position;
        Texture = texture;
        Size = size;
        CanvasModulate = canvasModulate ?? Color.White;
        RenderableObjects.Add(this);
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (Texture != null)
        {
            spriteBatch.Draw(Texture, Position, null, CanvasModulate, 0f, Vector2.Zero, Size, SpriteEffects.None, 0f);
        }
    }
    public void Remove()
    // Removes the object from the list
    {
        RenderableObjects.Remove(this);
    }
}