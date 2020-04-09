using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class CircleCharacter:Unit
    {
        private double SearchRadius = 100;
        private float ownRadius = Game.measurment / 2;
       
        public override void PlaneFoodUpgrade()
        {
            base.PlaneFoodUpgrade();
            if (Size < Game.MaxObjSize)
            {
                ownRadius += 1f;
                Size = 2 * ownRadius;
                pos = obj.Position;
                obj = new CircleShape(ownRadius);
                obj.Texture = text;
                obj.Position = pos;
            }
        }

        public override void AfterEnemyUpgrade()
        {
            base.AfterEnemyUpgrade();
            {
                ownRadius += 5;
                Size = 2 * ownRadius;
                pos = obj.Position;
                obj = new CircleShape(ownRadius);
                obj.Texture = text;
                obj.Position = pos;
            }
        }


    }
}
