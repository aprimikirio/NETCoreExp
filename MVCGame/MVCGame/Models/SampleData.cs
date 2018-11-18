using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCGame.Models
{
    public class SampleData
    {
        public static void Initialize(GameContext context)
        {
            if (!context.Games.Any())
            {
                context.Games.AddRange(
                    new Game
                    {
                        Id = 0,
                        Name = "Sample Game"
                    }
                );
                context.SaveChanges();
            }
            if (!context.Squares.Any())
            {
                context.Squares.AddRange(
                    new Square
                    {
                        Id = 0,
                        GameId = 0,
                        Edge = 100,
                        X = 0,
                        Y = 0
                    }
                );
                context.SaveChanges();
            }
        }
        public static void Initialize(PublicationContext context)
        {
            if (!context.Publications.Any())
            {
                context.Publications.AddRange(
                    new Publication
                    {
                        Id = 0,
                        Title = "Test",
                        Text = "Text",
                        ImageName = "test.png"
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
