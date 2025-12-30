using System;
using System.Collections.Generic;
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
    private Player playerObject;
    private SpriteFont MenuFont; // Variable to store the menu font
    private Theme MenuTheme;
    private Label2D label;
    private Player player2Object; // Variable to store the second player object
    private Vector2 player2Position; // Variable to store the second player's position
    private List<Bomb> bombs = new List<Bomb>(); // List to store the bombs
    private bool TimeOn = false;

    private GameObject[][] grid = new GameObject[14][];
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
        player2Position = new Vector2(playerPosition.X + 50, playerPosition.Y + 50); // Offset for the second player
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
        playerObject = new Player(playerPosition, icon, 0.25f, Color.Green);
        player2Object = new Player(player2Position, icon, 0.25f, Color.Blue);
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

        // Example: Update player position based on input
        Vector2 playerVelocity = new Vector2(0, 0); // Reset position for each update
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Up))
        {
            playerVelocity.Y -= 1; // Move up
        }
        if (state.IsKeyDown(Keys.Down))
        {
            playerVelocity.Y += 1; // Move down
        }
        if (state.IsKeyDown(Keys.Left))
        {
            playerVelocity.X -= 1; // Move left
        }
        if (state.IsKeyDown(Keys.Right))
        {
            playerVelocity.X += 1; // Move right
        }
        if (playerVelocity != Vector2.Zero)
        {
            playerVelocity = Vector2.Normalize(playerVelocity); //Limit the diagonal speed of the player
            playerPosition += playerVelocity * playerSpeed; // Update the player's position
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
        /*if (state.IsKeyDown(Keys.W))
        {
            player2Position.Y -= 1; // Move up
        }
        if (state.IsKeyDown(Keys.S))
        {
            player2Position.Y += 1; // Move down
        }
        if (state.IsKeyDown(Keys.A))
        {
            player2Position.X -= 1; // Move left
        }
        if (state.IsKeyDown(Keys.D))
        {
            player2Position.X += 1; // Move right
        }*/
        player2Object.Position = player2Position; // Update the position of the second icon object

        if (state.IsKeyDown(Keys.Space))
        {
            // Example action when space is pressed
            Console.WriteLine("Space key pressed!");
            Texture2D bombImage = Content.Load<Texture2D>("Bomb");
            if (!TimeOn)
            {
                Bomb newBomb = new Bomb(playerObject.Position, Content.Load<Texture2D>("bomb"), 0.25f, Color.Red, Content.Load<Texture2D>("bomb-mask"), _spriteBatch);
                bombs.Add(newBomb);
            }
            TimeOn = true;
            Thread thread = new Thread(new ThreadStart(wait));
            thread.Start();
            //thread.Join();
            if (!TimeOn)
            {
                bombs.Remove(bombs[0]); // Remove the first bomb after 1 second
            }
        }

        base.Update(gameTime);
    }
    private void wait()
    {
        new Timer(1000).Start(out TimeOn);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        //Draw the "Icon" texture in the top left corner
        _spriteBatch.Begin();
        GraphicsDevice.Clear(Color.CornflowerBlue);
        foreach (var obj in RenderableObject.RenderableObjects)
        {
            obj.Draw(_spriteBatch); // Draw each renderable object
        }
        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                if (i % 2 == 0)
                {
                    grid[i][j] = new Wall(new Vector2(i * 10, j * 10), Content.Load<Texture2D>("Wall"), 1, Color.White);
                }
                else
                {
                    grid[i][j] = new TemporaryBody(new Vector2(i * 10, j * 10), Content.Load<Texture2D>("Coin"),-1,5);
                }
            }
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
