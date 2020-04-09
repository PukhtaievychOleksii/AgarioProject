using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class RectangleCharacter:Unit
    {
        public override void PlaneFoodUpgrade()
        {
            base.PlaneFoodUpgrade();
            if (Size < Game.MaxObjSize)
            {
                Size += 1;
                pos = obj.Position;
                obj = new RectangleShape(new Vector2f(Size, Size));
                obj.Texture = text;
                obj.Position = pos;
            }
        }

        public override void AfterEnemyUpgrade()
        {
            base.AfterEnemyUpgrade();
            Size += 10f;
            pos = obj.Position;
            obj = new RectangleShape(new Vector2f(Size, Size));
            obj.Texture = text;
            obj.Position = pos;
        }
    }
}
