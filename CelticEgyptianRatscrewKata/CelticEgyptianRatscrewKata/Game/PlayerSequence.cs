using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PlayerSequence : IPlayerSequence
    {
        private readonly Queue<string> _playerSequence = new Queue<string>();

        public void AddPlayer(string name)
        {
            _playerSequence.Enqueue(name); 
        }

        public void AdvanceToNextPlayer()
        {
            if (_playerSequence.Count > 0)
            {
                _playerSequence.Enqueue(_playerSequence.Dequeue());
            }
        }

        public bool IsCurrentPlayer(string name)
        {
            return _playerSequence.Count > 0 && _playerSequence.Peek() == name;
        }

    }

}