using System;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BombermanNEA;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Vector2 playerPosition; // Variable to store the player's position
    private float playerSpeed = 2.0f; // Variable to store the player's speed
    private Texture2D icon; // Variable to store the icon texture
    private RenderableObject playerObject;
    private KeyboardState previousKeyboardState;
    private SpriteFont MenuFont; // Variable to store the menu font
    private Theme MenuTheme;
    private Label2D label;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; // Set the width of the window
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; // Set the height of the window
        _graphics.ApplyChanges();
        //create a new Vector2 to store the position of the player
        playerPosition = new Vector2(100, 100); // default position
        previousKeyboardState = Keyboard.GetState(); // Initialize the keyboard state
        base.Initialize();
        this.Window.AllowUserResizing = true;
        this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

    }
    void Window_ClientSizeChanged(object sender, EventArgs e)
    {
        // Make changes to handle the new window size.            
    }


    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // Load your game content here
        // For example, you can load textures, fonts, etc.
        this.Window.Title = "New NEA Project"; // Set the window title
        icon = Content.Load<Texture2D>("Icon"); // Load the icon from the Content folder
        playerObject = new RenderableObject(playerPosition, icon, 0.25f, Color.Green);
        MenuFont = Content.Load<SpriteFont>("MenuFont"); // Load the menu font
        MenuTheme = new Theme("Default", Color.Black, Color.White, Color.Gray, Color.LightGray, MenuFont, 12);
        // Create a Label2D object to display text on the screen
        label = new Label2D(MenuTheme, new Vector2(10, 10), null, "Lorem ipsum dolor sit amet consectetur adipiscing elit. Dolor sit amet consectetur adipiscing elit quisque faucibus.", 1, 1.0f, Color.White);
        //RenderableObject.RenderableObjects.Add(label); // Add the label to the renderable objects list
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        KeyboardState currentKeyboardState = Keyboard.GetState();

    previousKeyboardState = currentKeyboardState; // Update for next frame

        // Example: Update player position based on input
        Vector2 playerMovement = new Vector2(0, 0); // Reset position for each update
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Up))
        {
            playerMovement.Y -= 1; // Move up
        }
        if (state.IsKeyDown(Keys.Down))
        {
            playerMovement.Y += 1; // Move down
        }
        if (state.IsKeyDown(Keys.Left))
        {
            playerMovement.X -= 1; // Move left
        }
        if (state.IsKeyDown(Keys.Right))
        {
            playerMovement.X += 1; // Move right
        }
        if (playerMovement != Vector2.Zero)
        {
            playerMovement = Vector2.Normalize(playerMovement); //Limit the diagonal speed of the player
            playerPosition += playerMovement * playerSpeed; // Update the player's position
        }
        if(playerPosition.X < (0 - (icon.Width * playerObject.Size))) // Check if player is out of bounds on the left
        {
            playerPosition.X += (Window.ClientBounds.Width + (icon.Width * playerObject.Size)); // Screen Wrap
        }
        if(playerPosition.X > (Window.ClientBounds.Width + (icon.Width * playerObject.Size))) // Check if player is out of bounds on the right
        {
            playerPosition.X = 0 - (icon.Width * playerObject.Size); // Screen Wrap
        }
        if(playerPosition.Y < (0 - (icon.Height * playerObject.Size))) // Check if player is out of bounds on the left
        {
            playerPosition.Y += (Window.ClientBounds.Height + (icon.Height * playerObject.Size)); // Screen Wrap
        }
        if(playerPosition.Y > (Window.ClientBounds.Height + (icon.Height * playerObject.Size))) // Check if player is out of bounds on the right
        {
            playerPosition.Y = 0 - (icon.Height * playerObject.Size); // Screen Wrap
        }
        playerObject.Position = playerPosition; // Update the position of the icon object

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //Draw the "Icon" texture in the top left corner
        _spriteBatch.Begin();
        foreach (var obj in RenderableObject.RenderableObjects)
        {
            obj.Draw(_spriteBatch); // Draw each renderable object
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
