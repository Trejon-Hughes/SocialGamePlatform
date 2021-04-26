using Microsoft.AspNet.Identity;
using SocialGamePlatform.Data;
using SocialGamePlatform.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialGamePlatform.Service
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    OwnerUserName = Thread.CurrentPrincipal.Identity.GetUserName(),
                    GenreTags = model.GenreTags,
                    Price = model.Price
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public object GetGameByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.Name == name);
                return
                    new GameDetail
                    {
                        OwnerUserName = entity.OwnerUserName,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        Rating = entity.Rating,
                        GenreTags = entity.GenreTags
                    };
            }
        }

        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    Name = e.Name,
                                    Price = e.Price,
                                    Rating = e.Rating,
                                    GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGameByGenre(string genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.GenreTags.Contains(genre))
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    Name = e.Name,
                                    Price = e.Price,
                                    Rating = e.Rating,
                                    GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGameByRating(double rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.Rating == rating)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    Name = e.Name,
                                    Price = e.Price,
                                    Rating = e.Rating,
                                    GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGameByPrice(decimal price)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.Price == price)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    Name = e.Name,
                                    Price = e.Price,
                                    Rating = e.Rating,
                                    GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
