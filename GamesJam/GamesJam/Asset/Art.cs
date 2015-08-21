using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2014TeamSemiColon
{

    static class Art
    {
        //public static Texture2D Player { get; private set; }
        public static Texture2D Pixel { get; private set; }		// a single white pixel

        public static SpriteFont Font { get; private set; }

        public static Texture2D PlayerTex { get; private set; }

        public static Texture2D Cat_EnTex { get; private set; }

        public static Texture2D LPlat { get; private set; }

        public static Texture2D LLPlat { get; private set; }

        public static Texture2D DPlat { get; private set; }

        public static Texture2D EPort { get; private set; }

        public static Texture2D gameover { get; private set; }

        public static void Load(ContentManager content)
        {
            //Example Usage
            PlayerTex = content.Load<Texture2D>("Textures//PlayerSpriteSheet");
            Cat_EnTex = content.Load<Texture2D>("Textures//CaterpillerFULLSHEET");
            LPlat = content.Load<Texture2D>("Textures//lsmall");
            LLPlat = content.Load<Texture2D>("Textures//ltallblock");
            DPlat = content.Load<Texture2D>("Textures//dsmall");
            EPort = content.Load<Texture2D>("Textures//PortalSpriteSheet");
            gameover = content.Load<Texture2D>("Textures//gameover");
            
            //Pixel = new Texture2D(Player.GraphicsDevice, 1, 1);
            //Pixel.SetData(new[] { Color.White });

            Font = content.Load<SpriteFont>("Fonts/Font");
        }
    }
}