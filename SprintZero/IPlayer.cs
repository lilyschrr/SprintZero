using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IPlayer
{
    Vector2 Position { get; set; }
    ISprite Sprite { get; }
    void Move(Vector2 direction);
    void Idle();
    void OnClick();
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}
