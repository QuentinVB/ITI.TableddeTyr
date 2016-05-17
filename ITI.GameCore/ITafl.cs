namespace ITI.GameCore
{
    public interface IReadOnlyTafl
    {
        Pawn this[int x, int y] { get; }
        int AttackerCount { get; }
        int DefenderCount { get; }
        bool HasKing { get; }
        int Height { get; }
        int Width { get; }
    }
    public interface ITafl : IReadOnlyTafl
    {
        new Pawn this[int x, int y] { get; set; }
    }
}