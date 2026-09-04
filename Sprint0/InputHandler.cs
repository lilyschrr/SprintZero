using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InputHandler : IController
{
    private IPlayer player;
    private MouseState previousMouseState;

    public InputHandler(IPlayer player)
    {
        this.player = player;
        this.previousMouseState = Mouse.GetState();
    }

    public void Update()
    {
        KeyboardState kbs = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;

        // Handle all movement for WASD / arrow keys input
        if (kbs.IsKeyDown(Keys.W) || kbs.IsKeyDown(Keys.Up))
            direction.Y -= 1;
        if (kbs.IsKeyDown(Keys.S) || kbs.IsKeyDown(Keys.Down))
            direction.Y += 1;
        if (kbs.IsKeyDown(Keys.A) || kbs.IsKeyDown(Keys.Left))
            direction.X -= 1;
        if (kbs.IsKeyDown(Keys.D) || kbs.IsKeyDown(Keys.Right))
            direction.X += 1;

        // Quit/close the application if Q is pressed
        if (kbs.IsKeyDown(Keys.Q))
        {
            Environment.Exit(0);
        }


        if (direction != Vector2.Zero)
        {
            // Move in the vector direction since nonzero
            direction.Normalize();
            player.Move(direction);
        }
        else
        {
            // Player is stationary
            player.Idle();
        }

        // Mouse click handler
        MouseState currentMouseState = Mouse.GetState();
        if (currentMouseState.LeftButton == ButtonState.Pressed && 
            previousMouseState.LeftButton == ButtonState.Released)
        {
            player.OnClick();
        }

        previousMouseState = currentMouseState;
    }
}