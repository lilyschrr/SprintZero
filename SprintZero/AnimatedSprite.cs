using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class AnimatedSprite : ISprite
{
    private Texture2D texture;
    private int rows;
    private int columns;
    private double timer;
    private double frameThreshold = 0.1; // 100ms per frame
    
    private int currentColumn;
    private int currentRow;

    public bool IsMoving { get; set; }

    public AnimatedSprite(Texture2D texture, int rows, int columns)
    {
        this.texture = texture;
        this.rows = rows;
        this.columns = columns;
        this.currentRow = 0;
    }

    public void ChangeAnimation(int animationRow)
    {
        // Ensures row parameter is valid regarding the sprite sheet
        if (animationRow < rows && currentRow != animationRow)
        {
            // Sets the row to the passed row value, start at first frame
            currentRow = animationRow;
            currentColumn = 0;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (!IsMoving)
        {
            // Reset to idle frame when stationary
            currentColumn = 0; 
            timer = 0;
            return;
        }

        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= frameThreshold)
        {
            // Cycles through columns of frames in order
            currentColumn = (currentColumn + 1) % columns;
            timer -= frameThreshold;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
    {
        int texWidth = texture.Width / columns;
        int texHeight = texture.Height / rows;

        // Move source rectangle based on sprite texture dimensions and current frame
        Rectangle sourceRectangle = new Rectangle(texWidth * currentColumn, texHeight * currentRow, texWidth, texHeight);


        spriteBatch.Draw(
            texture,
            position,
            sourceRectangle,
            Color.White,
            0f,
            Vector2.Zero,
            1.0f,
            spriteEffects,
            0f
        );
    }
}