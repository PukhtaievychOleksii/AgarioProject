using HelloWorld;
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

    class Game
    {
        public  const float measurment = 80f;
        public  RenderWindow window;
        private bool wantToClose = false;
        
        public List<Actor> actorList = new List<Actor>();
        public List<Unit> unitsList = new List<Unit>();
        public static readonly uint SCREEN_WIDTH = 1920;
        public static readonly uint SCREEN_HEIGHT = 1080;
        public static readonly float MaxObjSize = 100; 
        public List<Food> foodList = new List<Food>();
        private Image background = new Image(SCREEN_WIDTH, SCREEN_HEIGHT);
        private Physic physic = new Physic();
        private Controller controller = new Controller();
        public Unit Hero;
        public Vector2u ScreenResolution { get; private set; }
        public static uint framesPerSecond = 60;
        public Creator creator = new Creator();
        private int timer = 100;
        
     /*   private void ChangeResolution(Vector2u newResolution)
        {
            ScreenResolution = newResolution;
            RecreateWindow(ScreenResolution);
        }

        private void RecreateWindow(Vector2u ScreenResolution)
        {
            window = new RenderWindow(new VideoMode(ScreenResolution.X, ScreenResolution.Y), "SFML window");
            //window.Closed += new EventHandler(OnClose);
        }
        */
        public void Run()
        {
            Init();
            window = new RenderWindow(new VideoMode(SCREEN_WIDTH,SCREEN_HEIGHT), "SFML window");
            window.Position = new Vector2i(-10, 0);
            window.SetFramerateLimit(framesPerSecond);
            while (IsGameRun())
            {
               
                Input();
                Logic();
                Draw();
            }
        }

        private void Init()
        {
           // window = new RenderWindow(new VideoMode(800, 800), "SFML window");
            Content.Load();
            //create background

            
            creator.CreateUnits(this);
            


        }

        public void Input()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) wantToClose = true;
                
        }

        public void Logic()
        {
            timer--;
            creator.CreateFood(this);
            if(timer <= 0)
            {
                timer = 100;
                controller.LedaAIobjects(unitsList, foodList);
                
            }
          //  controller.LedaAIobjects(unitsList, foodList);

            controller.LeadHero(Hero);
            physic.Update(unitsList,foodList,this);
            DestroyActors();
            creator.CheckAmountInGame(this);
            
        }

        public bool IsGameRun()
        {
            return window.IsOpen && !wantToClose;
        }

        public void Draw()
        {
            window.Clear();
            
            foreach(Drawable @object in actorList)
            {
                //@object.Draw(window, RenderStates.Default);
                window.Draw(@object);
            }
           
            window.Display();
        }

        
        public void RegisterActor(Actor actor)
        {
            actorList.Add(actor);
            
        }

        public void RegisterFood(Food food)
        {
            foodList.Add(food);
        }

        public void RegisterUnit(Unit unit)
        {
            unitsList.Add(unit);
        }

        public  void DestroyActors()
        {
            /*   if (actor is Food) foodList.Remove(actor as Food);
               if (actor is Unit) unitsList.Remove(actor as Unit);
               actorList.Remove(actor);
               */
            List<Actor> toDeleate = new List<Actor>();
            foreach(Actor actor in actorList)
            {
                if (actor.IsDeleated)
                {
                    if (actor is Unit) unitsList.Remove(actor as Unit);
                    if (actor is CircleCharacter) creator.PlaneAmount--;
                    if (actor is RectangleCharacter) creator.FirstAmount--;
                    if (actor is Food) foodList.Remove(actor as Food);
                    toDeleate.Add(actor);
                }
            }
            foreach (Actor act in toDeleate) actorList.Remove(act);
        }
    }
}
