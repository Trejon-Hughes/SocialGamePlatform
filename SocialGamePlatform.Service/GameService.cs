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
                    //GenreTags = model.GenreTags,
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
                var query =
                    ctx
                        .Games
                        .ToList()
                        .Where(e => e.Name.ToLower() == name.ToLower())
                        .Select(
                            e =>
                                new GameDetail
                                {
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
                                    Rating = e.Rating,
                                    Description = e.Description,
                                    Achievements = e.Achievements,
                                    Reviews = e.Reviews
                                    //GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .ToList()
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
                                    Rating = e.Rating,
                                    //GenreTags = e.GenreTags
                                }
                        ); ;
                return query.ToArray();
            }
        }
        public object GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .ToList()
                        .Where(e => e.GameId == id)
                        .Select(
                            e =>
                                new GameDetail
                                {
                                    OwnerUserName = e.OwnerUserName,
                                    GameId = e.GameId,
                                    Name = e.Name,
                                    Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
                                    Rating = e.Rating,
                                    Description = e.Description,
                                    Achievements = e.Achievements,
                                    Reviews = e.Reviews
                                    //GenreTags = e.GenreTags
                                }
                        );
                return query.ToArray();
            }
        }


        //public IEnumerable<GameListItem> GetGameByGenre(string genre)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Games
        //                .ToList()
        //                .Where(e => e.GenreTags.Contains(genre, StringComparer.OrdinalIgnoreCase))
        //                .Select(
        //                    e =>
        //                        new GameListItem
        //                        {
        //                            GameId = e.GameId,
        //                            Name = e.Name,
        //                            Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
        //                            Rating = e.Rating,
        //                            GenreTags = e.GenreTags
        //                        }
        //                );
        //        return query.ToArray();
        //    }
        //}

        //public IEnumerable<GameListItem> GetGameByRating(double rating)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Games
        //                .ToList()
        //                .Where(e => e.Rating == rating)
        //                .Select(
        //                    e =>
        //                        new GameListItem
        //                        {
        //                            GameId = e.GameId,
        //                            Name = e.Name,
        //                            Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
        //                            Rating = e.Rating,
        //                            //GenreTags = e.GenreTags
        //                        }
        //                );
        //        return query.ToArray();
        //    }
        //}

        //public IEnumerable<GameListItem> GetGameByPrice(decimal price)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Games
        //                .ToList()
        //                .Where(e => e.Price == price)
        //                .Select(
        //                    e =>
        //                        new GameListItem
        //                        {
        //                            GameId = e.GameId,
        //                            Name = e.Name,
        //                            Price = decimal.Round(e.Price, 2, MidpointRounding.AwayFromZero),
        //                            Rating = e.Rating,
        //                            //GenreTags = e.GenreTags
        //                        }
        //                );
        //        return query.ToArray();
        //    }
        //}

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .SingleOrDefault(e => e.GameId == model.GameId && e.OwnerId == _userId);

                if (entity == null)
                {
                    return false;
                }
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = decimal.Round(model.Price, 2, MidpointRounding.AwayFromZero);
                //entity.GenreTags = model.GenreTags;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .SingleOrDefault(e => e.GameId == gameId && e.OwnerId == _userId);

                if (entity == null)
                {
                    return false;
                }
                ctx.Games.Remove(entity);

                var reviewEntities = ctx.Reviews.Where(e => e.GameId == gameId);

                foreach (var review in reviewEntities)
                {
                    ctx.Reviews.Remove(review);
                }

                var achievementEntities = ctx.Achievements.Where(e => e.GameId == gameId);

                foreach (var achievement in achievementEntities)
                {
                    ctx.Achievements.Remove(achievement);
                }
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
