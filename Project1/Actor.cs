using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    class Actor:Drawable
    { 
    
        public Shape obj;
        public Texture text;
        public Vector2f pos;
        public float Size = Game.measurment;
        public bool IsDeleated = false;



        public void PostCreate(ActorArgs args)
        {
            obj = args.m_shape;
            text = args.m_texture;
            pos = args.m_position;
          

            obj.Texture = text;
            obj.Position = pos;
        }
        public void Draw(RenderTarget target, RenderStates renderstate)
        {
            target.Draw(obj);
        }

     /*   public void Display(Game game)
        {
            game.window.Display(this);
        }*/

        public float GetSize()
        {
            return Size;
        }
        public Vector2f GetPosition()
        {
            return new Vector2f(obj.Position.X + GetSize() / 2, obj.Position.Y + GetSize() / 2);
        }
    }
}
