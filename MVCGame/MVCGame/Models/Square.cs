using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCGame.Models
{
    public class Square
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int Edge { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
