using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Reflection;
using Microsoft.Xna.Framework.Media;

namespace GameJam2014TeamSemiColon
{
    public class MainMenu : MenuScreen
    {
        Texture2D backgroundTexture;
        SpriteFont kootenay10Font;

        public MainMenu()
        {
            TransitionOffTime = TimeSpan.FromSeconds(0);

            Selected = Color.CornflowerBlue;
            UnSelected = Color.White;
        }

        public override void LoadContent()
        {
            // Reload the content manager and loads up the ScreensSettings.xml for reading
            ContentManager Content = ScreenManager.Game.Content;

            Globals.Initialise();

            // Loads the menu titles.
            // #### Should be loading the array of items, then passing them through the MenuEntriesText function.
            MenuEntriesText.Add("Start Game");
            MenuEntriesText.Add("Settings");
            MenuEntriesText.Add("Exit");

            // Works out how many items are in the list and then distances itself from the bottom.
            int menudistancebottom = (35 * MenuEntriesText.Count);
            int actualmenudistance = 720 - menudistancebottom;
            StartPosition = new Vector2(50, actualmenudistance);

            backgroundTexture = Content.Load<Texture2D>("Textures\\MenuScreen");
            MenuText = Content.Load<SpriteFont>("Fonts\\Font");

            base.LoadContent();
        }

        public override void Remove()
        {
            base.Remove();
            MenuEntriesText.Clear();
        }

        public override void MenuSelect(int menuselected)
        {
            ExitScreen();
            switch (menuselected)
            {
                case 0: ScreenManager.AddScreen(new Intro()); break;
                case 1: ScreenManager.AddScreen(new Settings()); break;
                case 2: ScreenManager.Game.Exit(); break;
            }
        }

        public override void MenuCancel()
        {
            ExitScreen();
        }

        public override void Update(GameTime gameTime, bool covered)
        {
            base.HandleInput();
            base.Update(gameTime, covered);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null);
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Art.Font, "SUPER AMAZING AWESOME GAME! WEW!", new Vector2(9, 299), Color.Black);
            spriteBatch.DrawString(Art.Font, "SUPER AMAZING AWESOME GAME! WEW!", new Vector2(10, 300), Color.SeaGreen);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}