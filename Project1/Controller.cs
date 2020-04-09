using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Controller
    {
        public void LedaAIobjects(List<Unit> unitsList,List<Food> foodList)
        {
            foreach (Unit un in unitsList)
            {
                un.FindFoodTarget(foodList);
                un.FindEnemyTarget(unitsList);
            }
        }

        public void LeadHero(Unit hero)
        {
            hero.SetMoveTarget((Vector2f)Mouse.GetPosition());
            
            
        }
    }
}
