using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinPong.Core;

namespace ConsolaPingPong
{
    public class Tablero : IGameObject
    {
        public int Ancho { get; set; } = 60;
        public int Alto { get; set; } = 20;
        public Pelota Pelota { get; set; }
        public Tablero(Pelota pelota) 
        {
            Pelota = pelota;
        }

        public void OnDraw()
        {
            for (int i = 1; i < Ancho + 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("_");
                Console.SetCursorPosition(i, Alto);
                Console.Write("_");
            }

            for (int i = 1; i < Alto; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("|");
                Console.SetCursorPosition(Ancho, i);
                Console.Write("|");
            }
        }
    }
}
