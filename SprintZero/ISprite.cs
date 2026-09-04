using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ISprite
{
    bool IsMoving { get; set; }
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects);
    void ChangeAnimation(int animationRow);
}