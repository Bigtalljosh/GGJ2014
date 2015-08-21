using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2014TeamSemiColon
{
    class Sprite
    {
        
        protected Texture2D texture;
        protected Vector2   velocity;
        public Vector2 centre,screenpos;
        protected Rectangle sourceRect;
        protected bool collidedCheck;

        public Sprite(Texture2D texture, Vector2 centre, Vector2 screenpos, Vector2 velocity,Rectangle sourceRect)
        {
            this.texture = texture;
            this.centre = centre;
            this.screenpos = screenpos;
            this.velocity = velocity;
            this.sourceRect = sourceRect;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch,Viewport viewport)
        {
        }

        public virtual Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Math.Round(screenpos.X),
                    (int)Math.Round(screenpos.Y),
                    texture.Width,
                    texture.Height);
            }
        }

        public virtual bool CollidesWith(Sprite sprite)
        {
            return this.BoundingBox.Intersects(sprite.BoundingBox);
        }

        public bool collideCheck()
        {
            collidedCheck = true;
            return collidedCheck;
        }
    }
}
