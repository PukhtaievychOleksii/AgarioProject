using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class VectorHelper
    {
        public static double FindDistance(Vector2f a, Vector2f b)
        {
            float deltaX = Math.Abs(a.X - b.Y);
            float deltaY = Math.Abs(a.Y - b.Y);
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        }

        public static bool CheckPlaneCollis(Vector2f point,Actor body)
        {
            bool res = false;
            if(point.X > body.obj.Position.X && point.X < (body.obj.Position.X + body.GetSize()) && point.Y > body.obj.Position.Y && point.Y < (body.obj.Position.Y + body.GetSize())){
                res = true;
            }
            return res;
        } 

        public static bool CheckFullCollision(Actor first,Actor second)
        {
            float realisticCoef = 50;
            bool res = false;
            Vector2f point1 = new Vector2f(first.obj.Position.X + realisticCoef, first.obj.Position.Y + realisticCoef);
            Vector2f point2 = new Vector2f(first.obj.Position.X + first.GetSize() - realisticCoef, first.obj.Position.Y + realisticCoef);
            Vector2f point3 = new Vector2f(first.obj.Position.X + realisticCoef, first.obj.Position.Y + first.GetSize() - realisticCoef);
            Vector2f point4 = new Vector2f(first.obj.Position.X + first.GetSize() - realisticCoef, first.obj.Position.Y + first.GetSize() - realisticCoef);
            if (CheckPlaneCollis(point1, second) || CheckPlaneCollis(point2, second) || CheckPlaneCollis(point3, second) || CheckPlaneCollis(point4, second)) res = true;
            return res;
        }
        public static Vector2f GetDirectionFromVector(Vector2f vec)
        {
            double lenght = Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
            return new Vector2f((float)(vec.X / lenght), (float)(vec.Y / lenght));
        }

       /* public static Vector2f operator -(Vector2f a, Vector2f b)
        {
            float newx = a.X- b.X;
            float newy = a.Y - b.Y;
            return new Vector2f(newx, newy);

        }
        */
        public static Vector2f minusVectors(Vector2f a,Vector2f b)
        {
            float newx = a.X - b.X;
            float newy = a.Y - b.Y;
            return new Vector2f(newx, newy);
        }

        public static void OttolkObjects(Unit a,Unit b)
        {
            Vector2f RadiusVector1 = minusVectors(b.GetPosition(),a.GetPosition());
            a.m_velocity = minusVectors(a.m_velocity, RadiusVector1);
            b.m_velocity = minusVectors(b.m_velocity, -RadiusVector1);
        }

        
    }
}
