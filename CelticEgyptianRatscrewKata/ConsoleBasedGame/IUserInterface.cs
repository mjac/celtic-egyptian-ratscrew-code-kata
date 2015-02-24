using System.Collections.Generic;

namespace ConsoleBasedGame
{
    internal interface IUserInterface
    {
        IEnumerable<PlayerInfo> GetPlayerInfoFromUser();
        bool TryReadUserInput(out char userInput);
    }
}