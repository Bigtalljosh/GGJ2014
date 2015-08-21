using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam2014TeamSemiColon
{
    class Platform : Sprite
    {
        public Texture2D platformTexture;

        public Platform(Texture2D texture, Vector2 centre, Vector2 screenPos, Vector2 velocity, Rectangle sourceRect)
            : base(texture, centre, screenPos, velocity, sourceRect)
        {
            platformTexture = texture;
        }

        public void Update(ScrollBackground sb)
        {
            if (Input.WasKeyPressedGame(Keys.Right))
            {
                screenpos.X -= 3;
            }
            else if (Input.WasKeyPressedGame(Keys.Left) && sb.scrollStop > 0)
            {
                screenpos.X += 3;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color c, Viewport viewport)
        {
            spriteBatch.Draw(texture, screenpos, sourceRect, c, 0.0f, centre, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
