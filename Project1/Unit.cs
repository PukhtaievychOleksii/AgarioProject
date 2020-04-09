using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    enum CharacterTypes
    {
        Plane,
        First
    }
    class Unit : Actor
    {
        public Vector2f m_velocity = new Vector2f(10, 10);
        public float m_speed = 200;
        private double SearchRadius = 100;
        public CharacterTypes m_type;
        public void checkBorders()
        {
            if (obj.Position.X > Game.SCREEN_WIDTH - GetSize()) m_velocity.X *= -1;
            if (obj.Position.X <= 0) m_velocity.X *= -1;
            if (obj.Position.Y <= 0) m_velocity.Y *= -1;
            if (obj.Position.Y > Game.SCREEN_HEIGHT - GetSize()) m_velocity.Y *= -1;
        }
        public void SetMoveTarget(Vector2f destination)
        {
            Vector2f FromToVector = destination - GetPosition();

            m_velocity = VectorHelper.GetDirectionFromVector(FromToVector);
        }
        //TODO: Every must have own AIController->BaseController{LeadTO();} and Update
        public void Move()
        {

            obj.Position += VectorHelper.GetDirectionFromVector(m_velocity) * m_speed / Game.framesPerSecond;
        }

        /*public void FindFoodTarget(List<Food> foodList)
        {
            foreach (Food food in foodList)
            {
                if (VectorHelper.FindDistance(obj.Position, food.obj.Position) < SearchRadius)
                {
                    SetMoveTarget(food.obj.Position - this.obj.Position + new Vector2f(Game.measurment / 2,Game.measurment / 2));
                }
            }
        } */

       

        public void FindFoodTarget(List<Food> foodList)
        {
            foreach (Food food in foodList)
            {
                if (VectorHelper.FindDistance(obj.Position + new SFML.System.Vector2f(GetSize() / 2, GetSize()) / 2, food.obj.Position + new SFML.System.Vector2f(food.GetSize() / 2, food.GetSize() / 2)) < SearchRadius)
                {
                    SetMoveTarget(food.obj.Position - this.obj.Position);
                }
            }
        }

        public virtual void FindEnemyTarget(List<Unit> unitsList)
        {

            foreach (Unit un in unitsList)
            {
                if (VectorHelper.FindDistance(this.GetPosition(), un.GetPosition()) < SearchRadius)
                {
                    if (un.m_type == m_type)
                    {
                        continue;
                    }
                    else
                    {
                        if (un.GetSize() > this.GetSize())
                        {
                            un.SetMoveTarget( this.GetPosition() - un.GetPosition());
                            this.m_velocity = un.m_velocity;
                        }
                        else
                        {
                            this.SetMoveTarget(un.GetPosition() - this.GetPosition());
                            un.m_velocity = this.m_velocity;
                        }
                    }
                }
            }
        }


        public virtual void AfterEnemyUpgrade()
        {
            if(GetSize() > 200)
            {
                IsDeleated = true;
            }
        }

        public virtual void PlaneFoodUpgrade()
        {
            if (m_speed > 50) m_speed--;

            // obj.Texture.Size += 10;
        }
    }
}
