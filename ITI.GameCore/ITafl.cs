namespace ITI.GameCore
{
    public interface ITafl
    {
        Pawn this[int x, int y] { get; set; }

        int AttackerCount { get; }
        int DefenderCount { get; }
        bool HasKing { get; }
        int Height { get; }
        int Width { get; }
    }
}