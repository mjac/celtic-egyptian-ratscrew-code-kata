namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var ratscrewGame = new RatscrewGame(new UserInterface());
            ratscrewGame.Play(new ConsoleLog());
        }
    }
}
