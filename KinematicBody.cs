using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BombermanNEA;

class KinematicBody : PhysicsBody // A kinematic body that can move and collide with other objects
{
    public Vector2 Velocity { get; set; } // The velocity of the kinematic body
    public bool is_colliding { get; set; } // Flag to indicate if the body is colliding with another object

    public KinematicBody(Vector2 position, Texture2D texture, float layerDepth, Color? color = null)
        : base(position, texture, layerDepth, color)
    {
        Velocity = Vector2.Zero; // Initialize velocity to zero
    }

    public void Move(Vector2 direction)
    {
        // Update the position based on the velocity and direction
        Position += direction * Velocity;
    }
}