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
using GamesJam;

namespace GameJam2014TeamSemiColon
{
    class Intro : GameScreen
    {
        private ScrollBackground FloorBackgroundL;
        public ScrollBackground CloudBackgroundL;
        private ScrollBackground BackgroundL;
        private ScrollBackground FloorBackgroundD;
        public ScrollBackground CloudBackgroundD;
        private ScrollBackground BackgroundD;
        private SpriteBatch spriteBatch;
        public PlayerSprite player;
        private EnemySprite enemy;
        private Portal portal;
        Viewport viewport;
        private Texture2D sunL;
        private Texture2D cloudsL;
        private Texture2D floorL;
        private Texture2D sunD;
        private Texture2D cloudsD;
        private Texture2D floorD;
        private Texture2D backl;
        private Texture2D backd;
        private Texture2D pit;
        GraphicsDevice graphics;
        private double totalTime = 0;
        private double lifeTime = 0;

        double pitposition = 1100;
        int textMod = 0;

        private Platform platform;

        private List<Platform> LplatformList;
        private List<Platform> DplatformList;

        private int lives;

        public override void Initialize()
        {
            ContentManager Content = ScreenManager.Game.Content;
            lives = 3;
            LplatformList = new List<Platform>();
            DplatformList = new List<Platform>();

            player = new PlayerSprite(Art.PlayerTex,
                new Vector2(Art.PlayerTex.Width / 4, Art.PlayerTex.Height / 2),
                new Vector2(150, 720),
                new Vector2(0,0),
                new Rectangle(0,0,64,64),
                1.0f, 1, 3, 3);

            enemy = new EnemySprite(Art.Cat_EnTex,
                new Vector2(96, 32),
                new Vector2(600, 680),
                new Vector2(2, 0),
                new Rectangle(0, 0, 192, 64),
                1.0f, 1, 2, 2);

            portal = new Portal(Art.EPort,
                new Vector2(26, 32),
                new Vector2(1500, 680),
                new Vector2(0, 0),
                new Rectangle(0, 0, 52, 64),
                1.0f, 1, 8, 8);

            LplatformList.Add(platform = new Platform(Art.LPlat,
                new Vector2(Art.LPlat.Width / 2, Art.LPlat.Height / 2),
                new Vector2(350, 675),
                new Vector2(0, 0),
                new Rectangle(0, 0, 64, 64)));

            DplatformList.Add(platform = new Platform(Art.DPlat,
                new Vector2(Art.DPlat.Width / 2, Art.DPlat.Height / 2),
                new Vector2(350, 675),
                new Vector2(0, 0),
                new Rectangle(0, 0, 64, 64)));

            LplatformList.Add(platform = new Platform(Art.LLPlat,
                new Vector2(Art.LLPlat.Width / 2, Art.LLPlat.Height / 2),
                new Vector2(975, 595),
                new Vector2(0, 0),
                new Rectangle(0, 0, 128, 256)));
                    
            spriteBatch = ScreenManager.SpriteBatch;
            viewport = ScreenManager.Game.GraphicsDevice.Viewport;
            base.Initialize();
        }

        public override void LoadContent()
        {

            graphics = ScreenManager.GraphicsDevice;
            spriteBatch = new SpriteBatch(graphics);
            ContentManager Content = ScreenManager.Game.Content;

            FloorBackgroundL = new ScrollBackground();
            CloudBackgroundL = new ScrollBackground();
            BackgroundL = new ScrollBackground();
            floorL = Content.Load<Texture2D>("Textures\\Floor");
            cloudsL = Content.Load<Texture2D>("Textures\\CloudsLong");
            sunL = Content.Load<Texture2D>("Textures\\SunBig");
            backl = Content.Load<Texture2D>("Textures\\1280lbg");

            FloorBackgroundD = new ScrollBackground();
            CloudBackgroundD = new ScrollBackground();
            BackgroundD = new ScrollBackground();
            floorD = Content.Load<Texture2D>("Textures\\dfloor");
            cloudsD = Content.Load<Texture2D>("Textures\\DarkCloudsLong");
            sunD = Content.Load<Texture2D>("Textures\\MoonBig");
            backd = Content.Load<Texture2D>("Textures\\1280dbg");
            pit = Content.Load<Texture2D>("Textures\\pitfall1");

            FloorBackgroundL.Load(graphics, floorL, 760);
            CloudBackgroundL.Load(graphics, cloudsL, 150);
            BackgroundL.Load(graphics, backl, 357);

            FloorBackgroundD.Load(graphics, floorD, 760);
            CloudBackgroundD.Load(graphics, cloudsD, 150);
            BackgroundD.Load(graphics, backd, 357);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime, bool covered)
        {
            if (lives > 0)
            {
                if (Input.WasKeyPressed(Keys.Escape))
                {
                    //Quit to menu
                    ScreenManager.AddScreen(new MainMenu());
                    ScreenManager.RemoveScreen(this);
                }

                if (Input.WasKeyPressed(Keys.L))
                {
                    lives--;
                }

                if (Input.WasKeyPressed(Keys.V))
                {
                    if (Globals.Instance.light)
                    {
                        Globals.Instance.light = false;
                    }
                    else
                    {
                        Globals.Instance.light = true;
                    }
                }
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Input.WasKeyPressedGame(Keys.Right))
                {
                    FloorBackgroundL.Update(elapsed * 300);
                    CloudBackgroundL.Update(elapsed * 75);
                    BackgroundL.Update(elapsed * 150);

                    FloorBackgroundD.Update(elapsed * 300);
                    CloudBackgroundD.Update(elapsed * 75);
                    BackgroundD.Update(elapsed * 150);

                    pitposition -= 3;
                    textMod -= 3;
                }

                else if (Input.WasKeyPressedGame(Keys.Left))
                {
                    FloorBackgroundL.Update(elapsed * -300);
                    CloudBackgroundL.Update(elapsed * -75);
                    BackgroundL.Update(elapsed * -150);

                    FloorBackgroundD.Update(elapsed * -300);
                    CloudBackgroundD.Update(elapsed * -75);
                    BackgroundD.Update(elapsed * -150);

                    pitposition += 3;
                    textMod += 3;
                }

                foreach (Platform p in LplatformList)
                {
                    if (player.CollidesWith(p))
                    {
                        player.collidesWithObstacle(p, gameTime);
                    }
                }

                if(player.CollidesWithPortal(portal))
                {
                    ScreenManager.AddScreen(new LevelComplete());
                    ScreenManager.RemoveScreen(this);
                }

                foreach (Platform p in DplatformList)
                {
                    if (player.CollidesWith(p))
                    {
                        player.collidesWithObstacle(p, gameTime);
                    }
                }

                if (player.CollidesWith(portal))
                {
                    ScreenManager.AddScreen(new Level1());
                    ScreenManager.RemoveScreen(this);
                }

                foreach (Platform p in DplatformList)
                {
                    p.Update(CloudBackgroundL);
                }

                foreach (Platform p in LplatformList)
                {
                    p.Update(CloudBackgroundL);
                }
                
                player.Update(gameTime);
                enemy.Update(gameTime, CloudBackgroundL);
                portal.Update(gameTime, CloudBackgroundL);

                base.Update(gameTime, covered);
            }

            else if(lives <= 0)
            {
                ScreenManager.AddScreen(new GameOver());
                ScreenManager.RemoveScreen(this);
            }
        }

        public bool collisionWithEnemy()
        {
            //if player gets hit remove life
            lives--;
            return true;
        }

        public override void Draw(GameTime gameTime)
        {
                ScreenManager.GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();

                if (Globals.Instance.light)
                {
                    BackgroundL.Draw(spriteBatch);
                    spriteBatch.Draw(sunL, new Rectangle(0, 0, 195, 195), Color.White);
                    FloorBackgroundL.Draw(spriteBatch);
                    CloudBackgroundL.Draw(spriteBatch);

                    foreach (Platform p in LplatformList)
                    {
                        p.Draw(spriteBatch, Color.White, viewport);
                    }
                }
                else
                {
                    BackgroundD.Draw(spriteBatch);
                    spriteBatch.Draw(sunD, new Rectangle(0, 0, 195, 195), Color.White);
                    FloorBackgroundD.Draw(spriteBatch);
                    CloudBackgroundD.Draw(spriteBatch);
                    spriteBatch.Draw(pit, new Rectangle((int)pitposition, 710, 256, 512), Color.White);

                    foreach (Platform p in DplatformList)
                    {
                        p.Draw(spriteBatch, Color.White, viewport);
                    }
                }

                enemy.Draw(gameTime, spriteBatch, Color.White);
                portal.Draw(gameTime, spriteBatch, Color.White);
                player.Draw(spriteBatch, viewport);

                spriteBatch.DrawString(Art.Font, "Use left and right to move", new Vector2(100 + textMod, 75), Color.Tomato);
                spriteBatch.DrawString(Art.Font, "Use space to jump", new Vector2(120 + textMod, 125), Color.Tomato);
                spriteBatch.DrawString(Art.Font, "Use 'V' to switch worlds", new Vector2(390 + textMod, 300), Color.Tomato);
                spriteBatch.DrawString(Art.Font, "Avoid the trap and reach the portal", new Vector2(1200 + textMod, 300), Color.Tomato);

                spriteBatch.End();
        }
    }
}
