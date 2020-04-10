using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public struct ActorArgs
    {
       public  Texture m_texture;
        public Shape m_shape;
        public Vector2f m_position;
       
        public ActorArgs(Texture texture,Shape shape,Vector2f position)
        {
            m_texture = texture;
            m_shape = shape;
            m_position = position;
            
        }
    }

   static class Factory
    {
        public static T CreateInternalActor<T>(this Game game,ActorArgs args) where T : Actor,new()
        {
            /*Actor actor = new Actor();
            actor.intr = args.intrect;
            actor.text = args.texture;
            actor.pos = args.position;
            actor.obj = args.shape;*/
            T t = new T();
            t.PostCreate(args);
            game.RegisterActor(t);
            if (t is Food) game.RegisterFood(t as Food);
            if (t is Unit) game.RegisterUnit(t as Unit);
            if (t is CircleCharacter) (t as Unit).m_type = CharacterTypes.Plane;
            if (t is RectangleCharacter) (t as Unit).m_type = CharacterTypes.First;
            return t;

        }
        public static T CreateMenuActor<T>(this Menu menu,ActorArgs args) where T: Actor, new()
        {  
            T t = new T();
            t.PostCreate(args);
            if (t is Menu_Button)
            {
                (t as Menu_Button).initialOrigin = args.m_shape.Origin;
                (t as Menu_Button).initialScale = args.m_shape.Scale;
                menu.RegisterMenuButton(t as Menu_Button);
            }
            menu.RegisterMenuActor(t);
            return t;
        }
       

    }
}
