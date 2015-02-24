namespace ConsoleBasedGame
{
    class Program
    {
        static void Main()
        {
            var ratscrewGame = new RatscrewGame(new ConsoleLog(), new UserInterface());
            ratscrewGame.Play();
        }
    }
}
