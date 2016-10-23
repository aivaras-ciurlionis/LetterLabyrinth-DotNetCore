/**
 * @(#) Player.cs
 */

using System;

namespace OP_LetterLabyrinth
{
    public class Player
    {
        private Point _position;

        public Player(Point point)
        {
            _position = point;
        }

        public Point GetPosition()
        {
            return _position;
        }

        public Point GetPositionAfterMove(Move move)
        {
            var position = new Point
            {
                X = _position.X,
                Y = _position.Y
            };
            switch (move)
            {
                case OP_LetterLabyrinth.Move.Right:
                    position.Y++;
                    break;
                case OP_LetterLabyrinth.Move.Down:
                    position.X++;
                    break;
                case OP_LetterLabyrinth.Move.Left:
                    position.Y--;
                    break;
                case OP_LetterLabyrinth.Move.Up:
                    position.X--;
                    break;
            }
            return position;
        }

        public Point Move(Move move)
        {
            _position = GetPositionAfterMove(move);
            return _position;
        }
    }
}