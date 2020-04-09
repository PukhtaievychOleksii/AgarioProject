using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Project1
{
    class Menu
    {
        public bool IsEndOfMenu = false;
        public RenderWindow window;
        public const uint MenuScreenWidth = 500;
        public const uint MenuScreenHeight = 300;
        public List<Actor> actor_menulist = new List<Actor>();

        public void Run()
        {

            Init();
            while (!IsEndOfMenu)
            {
                Input();
                //Logic();
                Draw();
            }
        }

        private void Init()
        {
            window = new RenderWindow(new VideoMode(MenuScreenWidth, MenuScreenHeight), "Menu Window");
            this.CreateMenuButton<Menu_Button>(new ActorArgs(Content.textureBurger, new RectangleShape(new SFML.System.Vector2f(Game.measurment, Game.measurment)), new SFML.System.Vector2f(100, 50)));
        }
        private void Input()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) IsEndOfMenu = true;
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) Logic();
        }


        private void Logic()
        {
            foreach(Menu_Button but in actor_menulist)
            {
                if (but.IsPressed(window))
                {
                    but.OnClick();
                   // IsEndOfMenu = true;
                }
            }
        }
        private void Draw()
        {
            window.Clear();
            foreach (Actor actor in actor_menulist) window.Draw(actor);

            window.Display();
        }

        public void RegisterMenuButton(Actor actor)
        {
            actor_menulist.Add(actor);
        }


    }
}
