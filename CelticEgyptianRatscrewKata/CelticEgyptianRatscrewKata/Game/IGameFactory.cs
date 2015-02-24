namespace CelticEgyptianRatscrewKata.Game
{
    public interface IGameFactory
    {
        IGameController Create(ILog log);
    }
}