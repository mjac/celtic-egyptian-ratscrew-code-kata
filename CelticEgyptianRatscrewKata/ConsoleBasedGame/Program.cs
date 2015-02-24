namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var log = new ConsoleLog();
            var userInterface = new UserInterface();

            var ratscrewGame = new RatscrewGame(log, userInterface);
            ratscrewGame.Play();
        }
    }
}
