namespace ITI.GameCore
{
    public interface IGame
    {
        bool IsAtkPlaying { get; }
        IReadOnlyTafl Tafl { get; }
        PossibleMove CanMove(int x, int y);
        Game DeepCopy();
        bool MovePawn(int x, int y, int x2, int y2);
        bool UpdateTurn();
    }
}