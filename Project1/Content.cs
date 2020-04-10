using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Content
    {
        private const string contentDir = "..\\Content\\Textures\\";
        private const string settingDir = "..\\Content\\Settings\\";
        public static Texture textureHead;
        public static Texture textureBody;
        public static Texture textureBurger;
        public static Texture textureStarSky;
        public static Texture textureStar;
        public static Texture textureForest;
      
        public static void Load()
        {
            textureHead = new Texture(contentDir + "OrangeSquare.png");
            textureBody = new Texture(contentDir + "Body.png");
            textureBurger = new Texture(contentDir + "crab_meat.png");
            textureStarSky = new Texture(contentDir + "StarSky.jpg");
            textureStar = new Texture(contentDir + "Star.png");
            textureForest = new Texture(contentDir + "Forest.jpg");
        }

       
    }


}
