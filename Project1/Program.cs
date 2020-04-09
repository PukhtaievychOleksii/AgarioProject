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
       



        static void Main(string[] args)
        {
            var streamWriter = new StreamWriter("..\\Content\\Settings\\Default.txt");
            streamWriter.WriteLine("WindowLenght:800");
            streamWriter.WriteLine("WindowHeight:500");
            streamWriter.Close();
        
            game = new Game();
            game.Run();
           
           
        }
   
    }
    
}