using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameJam2014TeamSemiColon
{
    public class Settings : GameScreen
    {
        private SpriteBatch spriteBatch;
        private Rectangle viewportRect;

        private List<String> settingsList = new List<string>();

        public override void Initialize()
        {
            spriteBatch = ScreenManager.SpriteBatch;
            settingsList.Add("FullScreen:");
            settingsList.Add("Volume:");
            settingsList.Add("Credits:");
            settingsList.Add("Back.");
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
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Art.Font, "Testing screen remove me later", new Vector2(100, 100), Color.Red);
            spriteBatch.End();
        }
    }
}