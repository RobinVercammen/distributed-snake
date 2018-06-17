using System;

namespace Snake.Gameloop.Contracts
{
    public class UpdateSnake
    {
        public Guid Id { get; set; }
        public SnakePostion[] Postions { get; set; }
    }
}