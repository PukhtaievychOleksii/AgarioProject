using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Project1
{
    class Creator
    {
        Random rand = new Random();
        public int PlaneAmount = 0;
        public int FirstAmount = 0;
        public void CreateFood(Game game)
        {
            if (game.foodList.Count < 10)
            {
               
                float xpos = rand.Next(0, (int)(Game.SCREEN_WIDTH - Game.measurment));
                float ypos = rand.Next(0, (int)(Game.SCREEN_HEIGHT - Game.measurment));
                game.CreateInternalActor<Food>(new ActorArgs(Content.textureBurger, new RectangleShape(new SFML.System.Vector2f(Game.measurment, Game.measurment)), new SFML.System.Vector2f(xpos, ypos)));

            }
        }

        public void CreateUnits(Game game)
        {
            game.CreateInternalActor<Actor>(new ActorArgs(Content.textureStarSky, new RectangleShape(new Vector2f(Game.SCREEN_WIDTH, Game.SCREEN_HEIGHT)), new Vector2f(0, 0)));
            game.CreateInternalActor<RectangleCharacter>(new ActorArgs(Content.textureStar, new RectangleShape(new Vector2f(Game.measurment, Game.measurment)), new SFML.System.Vector2f(50, 50)));
            game.Hero = game.unitsList.Last<Unit>();
            
        }

        public void CheckAmountInGame(Game game)
        {
            while (PlaneAmount < 3)
            {
                float xpos = rand.Next(0, (int)(Game.SCREEN_WIDTH - Game.measurment));
                float ypos = rand.Next(0, (int)(Game.SCREEN_HEIGHT - Game.measurment));
                game.CreateInternalActor<CircleCharacter>(new ActorArgs(Content.textureBody, new CircleShape(Game.measurment / 2), new SFML.System.Vector2f(xpos, ypos)));
                PlaneAmount++;
                
            }
            while (FirstAmount < 3)
            {
                float xpos = rand.Next(0, (int)(Game.SCREEN_WIDTH - Game.measurment));
                float ypos = rand.Next(0, (int)(Game.SCREEN_HEIGHT - Game.measurment));
                game.CreateInternalActor<RectangleCharacter>(new ActorArgs(Content.textureHead, new RectangleShape(new Vector2f(Game.measurment, Game.measurment)), new SFML.System.Vector2f(xpos, ypos)));
                FirstAmount++;
            }
        }

    }
}   

       

