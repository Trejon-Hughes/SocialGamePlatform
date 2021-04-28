using SocialGamePlatform.Data;
using SocialGamePlatform.Models.AchievementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGamePlatform.Service
{
    public class AchievementService
    {
        private readonly Guid _userId;

        public AchievementService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAchievement(AchievementCreate model)
        {
            var entity =
                new Achievement()
                {
                    CreatorId = _userId,
                    GameId = model.GameId,
                    Name = model.Name,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Achievements.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AchievementListItem> GetAchievementByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Achievements
                        .Where(e => e.Name.ToLower() == name.ToLower())
                        .Select(
                            e =>
                                new AchievementListItem
                                {
                                    GameName = e.GameName,
                                    Name = e.Name,
                                    Description = e.Description
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<AchievementListItem> GetAchievementByGame(string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Achievements
                        .Where(e => e.GameName.ToLower() == game.ToLower())
                        .Select(
                            e =>
                                new AchievementListItem
                                {
                                    GameName = e.GameName,
                                    Name = e.Name,
                                    Description = e.Description
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<AchievementListItem> GetAchievementById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Achievements
                        .Where(e => e.AchievementId == id)
                        .Select(
                            e =>
                                new AchievementListItem
                                {
                                    GameName = e.GameName,
                                    Name = e.Name,
                                    Description = e.Description
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateAchievement(AchievementEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementId == model.AchievementId && e.CreatorId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAchievement(int achievementId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Achievements
                        .Single(e => e.AchievementId == achievementId && e.CreatorId == _userId);

                ctx.Achievements.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
