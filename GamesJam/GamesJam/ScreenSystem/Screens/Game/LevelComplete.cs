using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameJam2014TeamSemiColon;
using Microsoft.Xna.Framework.Graphics;

namespace GamesJam
{
    class LevelComplete : GameScreen
    {
        SpriteBatch spriteBatch;

        public override void Initialize()
        {
            spriteBatch = ScreenManager.SpriteBatch;
            base.Initialize();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, bool covered)
        {
            if (Input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape) || Input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                ScreenManager.AddScreen(new MainMenu());
                ScreenManager.RemoveScreen(this);
            }
            base.Update(gameTime, covered);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Art.Font, "WELL DONE", new Microsoft.Xna.Framework.Vector2(550, 360), Microsoft.Xna.Framework.Color.Green);
            spriteBatch.End();
        }
    }
}
