// See https://aka.ms/new-console-template for more information
using ConsolaPingPong;

Console.WriteLine("Hello, World!");

Console.WriteLine("Es la misma intancia:" + (Game.Instance == Game.Instance));
// Game game = new Game();
Game.Instance.OnPlay();