using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinPong.Core;

namespace ConsolaPingPong 
{
    public class Jugador : IGameObject
    {
        public int Positionx { get; set; }
        public int Positiony { get; set; } = 0;
        public object? Source { get; set; }

        public ICommand MoveUp { get; set; }

        public ICommand MoveDown { get; set; }

        public Jugador()
        {
            MoveDown = new GameCommand(Down, CanMove);
            MoveUp = new GameCommand(Up, CanMove);
        }

        private bool CanMove(object down)
        {
            return true;
        }

        private void Up(object down)
        {
            Console.Write("");
        }

        private void Down(object down)
        {
            Console.Write("");
        }

        private void OnDown()
        {

        }

        public void OnDraw()
        {
            Console.SetCursorPosition(Positionx, Positiony);
            Console.Write(Source);
        }
    }
}
