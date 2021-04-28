using SocialGamePlatform.Data;
using SocialGamePlatform.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialGamePlatform.Service
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReview(ReviewCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.Accounts.Single(e => e.UserId == _userId);
                var game = ctx.Games.Single(e => e.GameId == model.GameId);
                var entity =
                    new Review()
                    {
                        ReviewerId = _userId,
                        GameId = model.GameId,
                        GameName = game.Name,
                        AccountId = account.AccountId,
                        ReviewerUserName = account.UserName,
                        Text = model.Text,
                        StoryRating = model.StoryRating,
                        GameplayRating = model.GameplayRating,
                        GraphicsRating = model.GraphicsRating
                    };

                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviewByGame(string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.GameName.ToLower() == game.ToLower())
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    GameName = e.GameName,
                                    ReviewerUserName = e.ReviewerUserName,
                                    Text = e.Text,
                                    StoryRating = e.StoryRating,
                                    GameplayRating = e.GameplayRating,
                                    GraphicsRating = e.GraphicsRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ReviewListItem> GetReviewByUsername(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.ReviewerUserName.ToLower() == userName.ToLower())
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    GameName = e.GameName,
                                    ReviewerUserName = e.ReviewerUserName,
                                    Text = e.Text,
                                    StoryRating = e.StoryRating,
                                    GameplayRating = e.GameplayRating,
                                    GraphicsRating = e.GraphicsRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ReviewListItem> GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        .Where(e => e.ReviewId == id)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    GameName = e.GameName,
                                    ReviewerUserName = e.ReviewerUserName,
                                    Text = e.Text,
                                    StoryRating = e.StoryRating,
                                    GameplayRating = e.GameplayRating,
                                    GraphicsRating = e.GraphicsRating,
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId && e.ReviewerId == _userId);

                entity.Text = model.Text;
                entity.StoryRating = model.StoryRating;
                entity.GameplayRating = model.GameplayRating;
                entity.GraphicsRating = model.GraphicsRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId && e.ReviewerId == _userId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
