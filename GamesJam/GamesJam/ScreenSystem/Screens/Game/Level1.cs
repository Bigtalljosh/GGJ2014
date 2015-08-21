using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameJam2014TeamSemiColon
{
    public class Level1 : GameScreen
    {
        private SpriteBatch spriteBatch;
        private Rectangle viewportRect;

        public override void Initialize()
        {
            spriteBatch = ScreenManager.SpriteBatch;
        }

        public override void Remove() { base.Remove(); }

        public override void Update(GameTime gameTime, bool covered)
        {
            base.Update(gameTime, false);

            if (Input.WasKeyPressed(Keys.Escape))
            {
                //Quit to menu
                ScreenManager.AddScreen(new MainMenu());
                ScreenManager.RemoveScreen(this);
            }
            else if (Input.WasKeyPressed(Keys.Space))
            {
                ScreenManager.AddScreen(new Level1());
                ScreenManager.RemoveScreen(this);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Art.Font, "PREPARE YOURSELF", new Vector2(100, 100), Color.Red);
            spriteBatch.DrawString(Art.Font, "PRESS SPACE BAR", new Vector2(110, 130), Color.Red);
            spriteBatch.End();
        }
    }
}