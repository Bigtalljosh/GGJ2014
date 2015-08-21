using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam2014TeamSemiColon
{
    class EnemySprite : Sprite
    {
        private Vector2 screenPos;
        private float scale;
        private int rows;
        private int columns;
        private int frames;
        private int currentFrame;
        private int secsPerUpdate;
        private int secsPassed;
        private Vector2 startingPos;

        public EnemySprite(Texture2D texture, Vector2 centre, Vector2 screenPos, Vector2 velocity, Rectangle sourceRect, float scale, int rows, int columns, int frames) 
            : base(texture, centre, screenPos, velocity, sourceRect)
        {
            this.texture = texture;
            this.centre = centre;
            this.screenPos = screenPos;
            this.sourceRect = sourceRect;
            this.rows = rows;
            this.columns = columns;
            this.frames = frames;
            this.velocity = velocity;
            currentFrame = -1;
            secsPerUpdate = 150;
            secsPassed = 0;
            this.scale = scale;
            startingPos = screenPos;
        }

        public void Update(GameTime gameTime, ScrollBackground sb)
        {
            screenPos += velocity;

            if (screenPos.X < startingPos.X - 100)
            {
                velocity.X = 2;
            }
            else if (screenPos.X > startingPos.X + 200)
            {
                velocity.X = -2;
            } 

            if (Input.WasKeyPressedGame(Keys.Right))
            {
                screenPos.X -= 3;
                startingPos.X -= 3;
            }
            else if (Input.WasKeyPressedGame(Keys.Left) && sb.scrollStop > 0)
            {
                screenPos.X += 3;
                startingPos.X += 3;
            }

            secsPassed += gameTime.ElapsedGameTime.Milliseconds;
            if (secsPassed >= secsPerUpdate)
            {
                if (Globals.Instance.light)
                {
                    currentFrame++;
                    currentFrame %= frames;
                    sourceRect.X = (currentFrame % columns) * sourceRect.Width;
                    sourceRect.Y = ((currentFrame / columns) * sourceRect.Height) + 65;
                    secsPassed = 0;
                }
                else
                {
                    currentFrame++;
                    currentFrame %= frames;
                    sourceRect.X = (currentFrame % columns) * sourceRect.Width;
                    sourceRect.Y = (currentFrame / columns) * sourceRect.Height;
                    secsPassed = 0;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb, Color c)
        {
            if(velocity.X <= 0)
            {
                sb.Draw(texture, screenPos, sourceRect, c, 0.0f, centre, scale, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                sb.Draw(texture, screenPos, sourceRect, c, 0.0f, centre, scale, SpriteEffects.None, 0);
            }
        }
    }
}
