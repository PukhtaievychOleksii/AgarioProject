using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Physic
    {
        public void Update(List<Unit> unitsList,List<Food> foodList,Game game)
        {
            //check food collission
            foreach (Unit un in unitsList)
            {
                un.Move(); un.checkBorders();

                foreach (Food food in foodList)
                {
                    if (VectorHelper.CheckFullCollision(un, food))
                    {
                        food.IsDeleated = true;
                        un.PlaneFoodUpgrade();
                        break;
                    }
                }
                //check units collisiion and battels
                if (un is CircleCharacter)
                {
                    foreach (Unit other in unitsList)
                    {
                        if ( VectorHelper.CheckFullCollision(un, other))
                        {
                            if (other is CircleCharacter) VectorHelper.OttolkObjects(un, other);
                            else CharacterBattle(un, other, game);
                        }
                        
                    }
                }
                
                if (un is RectangleCharacter)
                {
                    foreach (Unit other in unitsList)
                    {
                        if ( VectorHelper.CheckFullCollision(un, other))
                        {
                            if (other is RectangleCharacter) VectorHelper.OttolkObjects(un, other);
                            else CharacterBattle(un, other, game);
                        }
                    }
                }
            }
        }

        public void CharacterBattle(Unit a,Unit b,Game game)
        {
            if(a.GetSize() > b.GetSize())
            {
                b.IsDeleated = true;
                a.AfterEnemyUpgrade();
            }
            else if(b.GetSize() > a.GetSize())
            {
                a.IsDeleated = true;
                b.AfterEnemyUpgrade();
            }
        }
    }
}
