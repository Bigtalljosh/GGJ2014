using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameJam2014TeamSemiColon
{
    class PlayerSprite : Sprite
    {
        private float scale;
        private int rows;
        private int columns;
        private int frames;
        private int currentFrame;
        private int secsPerUpdate;
        private int secsPassed;
        private bool jumpFlag = false;
        private bool djumpFlag = false;
        private int lightCount = 1;
        private int darkCount = 1;

        public PlayerSprite(Texture2D texture, Vector2 centre, Vector2 screenpos, Vector2 velocity,Rectangle sourceRect, float scale, int rows, int columns, int frames)
            : base(texture, centre, screenpos, velocity, sourceRect)
        {
            this.texture = texture;
            this.centre = centre;
            this.screenpos = screenpos;
            this.velocity = velocity;
            this.sourceRect = sourceRect;
            this.rows = rows;
            this.columns = columns;
            this.frames = frames;
            currentFrame = -1;
            secsPerUpdate = 150;
            secsPassed = 0;
            this.scale = scale;
        }

        public void Update(GameTime gameTime)
        {
            if (!djumpFlag && !jumpFlag)
            {
                secsPassed += gameTime.ElapsedGameTime.Milliseconds;
                if (secsPassed >= secsPerUpdate)
                {
                    if (!Globals.Instance.light)
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

            else
            {
                sourceRect.X = 193;
                if (Globals.Instance.light)
                {
                    sourceRect.Y = 0;
                }
                else
                {
                    sourceRect.Y = 65;
                }
            }

            velocity *= 0.75f;
            if (Globals.Instance.light)
            {
                if (lightCount == 1)
                {
                    jumpFlag = true;
                    lightCount = 0;
                }
                if (lightCount == 0)
                {
                    if (jumpFlag == false)
                    {
                        if (Input.WasKeyPressed(Keys.Space))
                        {
                            lightCount++;
                            //Jump
                            //Bool to stop being continously pressed for anti -grav
                            jumpFlag = true;
                            velocity.Y += -100;
                        }
                    }
                }

                //Gravity
                velocity.Y += 1;
                screenpos += velocity;
                if (velocity.Y <= -100)
                {
                    velocity.Y = -50;
                }
                //Ground boundary -> player won't go below
                if (screenpos.Y + texture.Height >= 850)
                {
                    screenpos.Y = 850 - texture.Height;
                    jumpFlag = false;
                }
            }
            else if (!Globals.Instance.light)
            {
                if (darkCount == 1)
                {
                    djumpFlag = true;
                    darkCount = 0;
                }
                if (darkCount == 0)
                {
                    if (djumpFlag == false)
                    {
                        if (Input.WasKeyPressed(Keys.Space))
                        {
                            darkCount++;
                            //Jump
                            //Bool to stop being continously pressed for anti -grav
                            djumpFlag = true;
                            velocity.Y += -50;
                        }
                    }
                }
                //Gravity
                velocity.Y += 1;
                screenpos += velocity;
                if (velocity.Y <= -50)
                {
                    velocity.Y = -25;
                }
                //Ground boundary -> player won't go below
                if (screenpos.Y + texture.Height >= 850)
                {
                    screenpos.Y = 850 - texture.Height;
                    djumpFlag = false;
                }
            }
        }
        
        public override void Draw(SpriteBatch spriteBatch,Viewport viewport)
        {
            if(Input.WasKeyPressedGame(Keys.Left))
            {
                spriteBatch.Draw(texture, screenpos, sourceRect, Color.White, 0.0f, centre, 1.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }
            else 
            {
                spriteBatch.Draw(texture, screenpos, sourceRect, Color.White, 0.0f, centre, 1.0f, SpriteEffects.None, 0.0f);
            }

            
        }

        public void collidesWithObstacle(Platform platform, GameTime gameTime)
        {
            if(Globals.Instance.light)
            {
                if (screenpos.Y > platform.screenpos.Y - (platform.platformTexture.Height / 2))
                {
                    screenpos.Y = platform.screenpos.Y - platform.platformTexture.Height / 2;
                    if (Globals.Instance.light)
                    {
                        jumpFlag = false;
                    }
                    else if (!Globals.Instance.light)
                    {
                        djumpFlag = false;
                    }
                }
            }
        }

        public bool CollidesWithPortal(Sprite sprite)
        {
            if (this.BoundingBox.Intersects(sprite.BoundingBox))
                return true;
            if (sprite.BoundingBox.Intersects(this.BoundingBox))
                return true;
            if (sprite.screenpos.X + 64 <= this.BoundingBox.Left)
                return true;
            if (sprite.BoundingBox.Left <= this.BoundingBox.Right)
                return true;
            if (sprite.BoundingBox.Bottom <= this.BoundingBox.Top)
                return true;
            
            return false;
        }

        //public void collidesWithPortal(Sprite sprite, GameTime gameTime)
        //{
        //    if (Globals.Instance.light)
        //    {
        //        if (screenpos.Y > platform.screenpos.Y - (platformTexture.Height / 2))
        //        {
        //            screenpos.Y = platform.screenpos.Y - platform.platformTexture.Height / 2;
        //            if (Globals.Instance.light)
        //            {
        //                jumpFlag = false;
        //            }
        //            else if (!Globals.Instance.light)
        //            {
        //                djumpFlag = false;
        //            }
        //        }
        //    }
        //}

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Math.Round(screenpos.X),
                    (int)Math.Round(screenpos.Y),
                    64,
                    64);
            }
        }
    }
}
