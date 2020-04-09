using System;
using SFML.Window;
using SFML.Graphics;
using Project1;
using System.IO;

namespace HelloWorld
{
    class Program
    {



        public static Game game;
        public static Menu menu;



        static void Main(string[] args)
        {
            var streamWriter = new StreamWriter("..\\Content\\Settings\\Default.txt");
            streamWriter.WriteLine("WindowLenght:800");
            streamWriter.WriteLine("WindowHeight:500");
            streamWriter.Close();
            Content.Load();
            menu = new Menu();
            menu.Run();
            game = new Game();
            game.Run();
           
           
        }
   
    }
    
}