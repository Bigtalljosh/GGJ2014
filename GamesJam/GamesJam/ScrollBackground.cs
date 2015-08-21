using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam2014TeamSemiColon
{
    class ScrollBackground
    {
        private Vector2 screenpos, start, texturesize;
        private Texture2D level1Background;
        private Vector2 screenWidth;
        public int scrollStop = 0;

        public void Load(GraphicsDevice device, Texture2D backgroundTexture, int passedHeight)
        {
            level1Background = backgroundTexture;
            screenWidth.X = device.Viewport.Width;
            screenWidth.Y = device.Viewport.Height;
            start = new Vector2(0, level1Background.Height / 2);
            screenpos = new Vector2(0, passedHeight);
            texturesize = new Vector2(level1Background.Width, 0);
        }

        public void Update(float deltaX)
        {
            if (deltaX <= 0 && scrollStop <= 0)
            {
            }

            else
            {
                screenpos.X -= deltaX;
                screenpos.X = screenpos.X % level1Background.Width;

                if (deltaX < 0)
                {
                    scrollStop -= 1;
                }
                else
                {
                    scrollStop += 1;
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (screenpos.X < screenWidth.X)
            {
                batch.Draw(level1Background, new Vector2(screenpos.X + 2, screenpos.Y), null,
                     Color.White, 0, start, 1, SpriteEffects.None, 0f);
            }
            batch.Draw(level1Background, screenpos + texturesize, null,
                 Color.White, 0, start, 1, SpriteEffects.None, 0f);

            batch.Draw(level1Background, screenpos - texturesize, null,
                 Color.White, 0, start, 1, SpriteEffects.None, 0f);
        }
    }
}
