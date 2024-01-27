using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinPong.Core;

namespace ConsolaPingPong
{
    public class Pelota : IGameObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; } = 0;
        public object Source { get; set; }
        public Pelota() 
        {
        
        }

        public void OnDraw()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.WriteLine(Source);
        }
    }
}
