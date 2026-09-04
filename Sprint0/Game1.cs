using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SprintZero;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IPlayer player;
    private IController controller;
    SpriteFont font;
    Vector2 txtPos1, txtPos2;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // Load spritesheet (image is 2 rows & 4 columns)
        Texture2D playerSheet = Content.Load<Texture2D>("player-sheet");
        ISprite playerSprite = new AnimatedSprite(playerSheet, rows: 2, columns: 4);


        // Font positioning
        font = Content.Load<SpriteFont>("Arial");
        Viewport viewport = graphics.GraphicsDevice.Viewport;
        txtPos1 = new Vector2(viewport.Width / 2 , viewport.Height - 50);
        txtPos2 = new Vector2(130,30);

        // Player game object
        player = new Player(new Vector2(viewport.Width / 2 - 80, viewport.Height / 2 - 40), playerSprite);
        controller = new InputHandler(player);

    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update();
        player.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Tan);

        spriteBatch.Begin();

        player.Draw(spriteBatch);
        
        // Text Printing
        string output = "Credits:\nProgram Made By: Lily Scheerer\nSprites made by me";
        string info = "-Move with WASD or arrow keys\n-Click the screen to roll up\n-Press 'Q' to quit";

        // Find the center of the string and draw
        Vector2 FontOrigin = font.MeasureString(output) / 2;
        spriteBatch.DrawString(font, output, txtPos1, Color.Black, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
        spriteBatch.DrawString(font, info, txtPos2, Color.Black, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
