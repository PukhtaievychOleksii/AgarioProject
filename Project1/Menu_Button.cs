using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Menu_Button:Actor
    {
        public Vector2f initialOrigin;
        public Vector2f initialScale;
       
        public bool IsPressed(RenderWindow window)
        {

            bool res = false;
            if (checkXPos(window) && checkYPos(window)) res = true;
            return res;
        }

        private bool checkXPos(RenderWindow wind)
        {
            if (Mouse.GetPosition().X - wind.Position.X - 10 >= GetPosition().X && Mouse.GetPosition().X - wind.Position.X - 10 < (GetPosition().X + Game.measurment)) return true;
            else return false;
        }

        private bool checkYPos(RenderWindow wind)
        {
            if (Mouse.GetPosition().Y - wind.Position.Y - 35 >= GetPosition().Y && Mouse.GetPosition().Y - wind.Position.Y - 35 < (GetPosition().Y + Game.measurment)) return true;
            else return false;
        }

        public void IsChose()
        {
            
            this.obj.Origin = new SFML.System.Vector2f(10, 10);
            this.obj.Scale = new SFML.System.Vector2f(1.5f, 1.5f);

        }

        public void IsnNotChose()
        {
            obj.Origin = initialOrigin;
            obj.Scale = initialScale;
        }
    }
}
