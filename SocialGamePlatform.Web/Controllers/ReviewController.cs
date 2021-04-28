using Microsoft.AspNet.Identity;
using SocialGamePlatform.Models.ReviewModels;
using SocialGamePlatform.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocialGamePlatform.Web.Controllers
{
    public class ReviewController : ApiController
    {
        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewService(userId);
            return reviewService;
        }

        ///<summary>
        ///Adds a review
        ///</summary>
        [Authorize]
        public IHttpActionResult Post(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Searches reviews by game or username
        /// </summary>
        /// <param name="selection">Choose to search by game or username</param>
        /// <param name="search">The string to search by</param>
        [ResponseType(typeof(IEnumerable<ReviewListItem>))]
        public IHttpActionResult Get(string selection, string search)
        {
            ReviewService reviewService = CreateReviewService();
            if (selection.ToLower() == "game")
            {
                var review = reviewService.GetReviewByGame(search);
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound();
            }
            else if (selection.ToLower() == "userName")
            {
                var review = reviewService.GetReviewByUsername(search);
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound();
            }
            else
            {
                return BadRequest("Please enter a valid value for selection");
            }
        }

        /// <summary>
        /// Searches for review by ID
        /// </summary>
        /// <param name="id">ID of the review</param>
        [ResponseType(typeof(ReviewListItem))]
        public IHttpActionResult Get(int id)
        {
            ReviewService reviewService = CreateReviewService();

            var review = reviewService.GetReviewById(id);
            if(review != null)
            {
                return Ok(review);
            }
            return NotFound();
        }

        /// <summary>
        /// Allows an account to update a review they created
        /// </summary>
        [Authorize]
        public IHttpActionResult Put(ReviewEdit review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateReviewService();

            if (!service.UpdateReview(review))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Allows an account to delete a review they created
        /// </summary>
        /// <param name="id">Id of the review to be deleted</param>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReviewService();

            if (!service.DeleteReview(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
