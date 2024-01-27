using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinPong.Core;

namespace ConsolaPingPong
{
    public class Game
    {
        private IGameObject tablero;
        private Pelota pelota;
        private Jugador jugadorA;
        private Jugador jugadorB;

        private static Game? _instance;

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                };
                return _instance;
            }
            private set { }
        }

        public Game()
        {
            jugadorA = new Jugador();
            jugadorB = new Jugador();
            pelota = new Pelota();
            tablero = new Tablero(pelota);
            pelota.Source = "O";
            jugadorA.Source = "|";
            jugadorB.Source = "|";
            jugadorA.Positionx = 0;
            jugadorA.Positiony = ((Tablero)tablero).Alto / 2;
            jugadorB.Positionx = ((Tablero)tablero).Ancho;
            jugadorB.Positiony = ((Tablero)tablero).Alto / 2;
            Console.CursorVisible = false;
        }
        public void OnPlay()
        {
            int velocidadx = 1;
            int velocidady = 1;
            while (true)
            {
                tablero.OnDraw();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    // Movimiento del jugadorA
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                        jugadorA.Positiony -= 1;
                        jugadorA.Positionx = 2;
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                        jugadorA.Positiony += 1;
                    if (jugadorA.Positiony < 0)
                        jugadorA.Positiony = 0;
                    if (jugadorA.Positiony > ((Tablero)tablero).Alto)
                        jugadorA.Positiony = ((Tablero)tablero).Alto;
                    if (jugadorA.Positionx < ((Tablero)tablero).Ancho - 1)
                        jugadorA.Positionx = 2;

                    // Movimiento del jugadorB
                    if (keyInfo.Key == ConsoleKey.W)
                        jugadorB.Positiony -= 1;
                        jugadorB.Positionx = 58;
                    if (keyInfo.Key == ConsoleKey.S)
                        jugadorB.Positiony += 1;
                    if (jugadorB.Positiony < 0)
                        jugadorB.Positiony = 0;
                    if (jugadorB.Positiony > ((Tablero)tablero).Alto)
                        jugadorB.Positiony = ((Tablero)tablero).Alto;
                    if (jugadorB.Positionx < ((Tablero)tablero).Alto - 1)
                        jugadorB.Positionx = 58;

                }


                #region Se pinta Jugador A
                Console.SetCursorPosition(jugadorA.Positionx, jugadorA.Positiony);
                Console.Write(jugadorA.Source);
                #endregion

                #region Se pinta Jugador B
                Console.SetCursorPosition(jugadorB.Positionx, jugadorB.Positiony);
                Console.Write(jugadorB.Source);
                #endregion

                #region Se pinta la Pelota
                Console.SetCursorPosition(pelota.PositionX, pelota.PositionY);
                Console.Write(pelota.Source);
                #endregion

                pelota.PositionX += velocidadx;
                pelota.PositionY += velocidady;

                // Comprobar si la pelota golpea al jugadorA
                if (pelota.PositionX == jugadorA.Positionx && pelota.PositionY == jugadorA.Positiony)
                    velocidadx = 1;

                // Comprobar si la pelota golpea al jugadorB
                if (pelota.PositionX == jugadorB.Positionx && pelota.PositionY == jugadorB.Positiony)
                    velocidadx = -1;

                if (pelota.PositionX >= ((Tablero)tablero).Ancho)
                    velocidadx = -1;
                if (pelota.PositionX <= 0)
                    velocidadx = 1;
                if (pelota.PositionY >= ((Tablero)tablero).Alto)
                    velocidady = -1;
                if (pelota.PositionY <= 0)
                    velocidady = 1;
                Thread.Sleep(10);
                Console.Clear();
            }
        }

        public void OnPause()
        {

        }

    }
}
