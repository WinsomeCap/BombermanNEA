using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BombermanNEA;

public class PhysicsBody : GameObject
{
    public static List<PhysicsBody> Bodies = new List<PhysicsBody>(); // Static list to hold all physics bodies ; Let them hit the floor.
    public Rectangle CollisionShape { get; set; } // The collision shape of the physics body
    public bool Enabled { get; set; } = true; // Flag to indicate if the collision shape is enabled
    public bool IsColliding { get; set; } // Flag to indicate if the body is colliding with another object
    public PhysicsBody(Vector2 position, Texture2D texture, float size = 1.0f, Color? color = null)
        : base(position, texture, size, color)
    {
        // Initialize the collision shape based on the texture size
        CollisionShape = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        Bodies.Add(this); // Add this physics body to the static list
    }
    public void Update(GameTime gameTime)
    {
        // Update the collision shape position based on the current position
        CollisionShape = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        // Check for collisions with other physics bodies
        IsColliding = false; // Reset the collision flag
        foreach (var body in Bodies)
        {
            if (body != this && body.Enabled && CollisionShape.Intersects(body.CollisionShape))
            {
                IsColliding = true; // Set the collision flag if a collision is detected
                base.color = Color.White; // Change color to red if colliding
                body.color = Color.White; // Change the other body's color to red as well
                _Collide(body); // Call the collision handler method
                body._Collide(this); // Call the collision handler on the other body
                break; // Exit the loop if a collision is found
            }
        }
    }
    public virtual void _Collide(PhysicsBody other)
    {
        // This method can be overridden in derived classes to handle specific collision behavior
        // For now, it does nothing
    }

}