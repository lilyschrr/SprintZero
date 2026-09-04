using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Player : IPlayer
{
    public Vector2 Position { get; set; }
    public ISprite Sprite { get; private set; }
    private float speed = 200f;
    private bool isClickedState = false;
    private SpriteEffects spriteEffects = SpriteEffects.None;

    public Player(Vector2 startPos, ISprite sprite)
    {
        Position = startPos;
        Sprite = sprite;
    }

    public void Move(Vector2 direction)
    {
        Sprite.IsMoving = true;
        Position += direction * speed * 0.016f;

        // Flip horizontally based on movement
        if (direction.X > 0)
        {
            // Facing right
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
        else if (direction.X < 0)
        {
            // Facing left (default)
            spriteEffects = SpriteEffects.None;
        }
    }

    public void Idle()
    {
        Sprite.IsMoving = false;
    }

    public void OnClick()
    {
        // Animation is swapped between walking (0) and rolling (1) based on state
        isClickedState = !isClickedState;
        Sprite.ChangeAnimation(isClickedState ? 1 : 0);
    }

    public void Update(GameTime gameTime)
    {
        Sprite.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Position, spriteEffects);
    }
}