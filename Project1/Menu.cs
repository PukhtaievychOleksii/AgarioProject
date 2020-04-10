using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
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
        public List<Menu_Button> button_menuList = new List<Menu_Button>();

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
            //Creating background
            this.CreateMenuActor<Actor>(new ActorArgs(Content.textureForest, new RectangleShape(new Vector2f(MenuScreenWidth, MenuScreenHeight)), new Vector2f(0, 0)));
            this.CreateMenuActor<Menu_Button>(new ActorArgs(Content.textureHead, new RectangleShape(new SFML.System.Vector2f(Game.measurment, Game.measurment)), new SFML.System.Vector2f(100, 80)));
            this.CreateMenuActor<Menu_Button>(new ActorArgs(Content.textureBody, new CircleShape(Game.measurment / 2), new SFML.System.Vector2f(300, 80)));

        }
        private void Input()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) IsEndOfMenu = true;
            if (Mouse.IsButtonPressed(Mouse.Button.Left)) Logic();
        }


        private void Logic()
        {
            Menu_Button pressedButton;
            foreach(Menu_Button but in button_menuList)
            {
                but.IsnNotChose();
                if (but.IsPressed(window))
                {
                    pressedButton = but;
                    but.IsChose();
                   // IsEndOfMenu = true;
                }
            }
            //if(pressedButton != null) pressedButton.OnClick();
        }
        private void Draw()
        {
            window.Clear();
            foreach (Actor actor in actor_menulist) window.Draw(actor);

            window.Display();
        }

        public void RegisterMenuActor(Actor actor)
        {
            actor_menulist.Add(actor);
        }

        public void RegisterMenuButton(Menu_Button button)
        {
            button_menuList.Add(button);
            
        }


    }
}
