/**
 * @(#) IGraphics.cs
 */

namespace OP_LetterLabyrinth
{
    public interface IGraphics
    {
        void DrawTurn(Player player, LetterGrid grid, Dictionary dictionary);
        void DrawVictory(Dictionary dictionary);
    }
}