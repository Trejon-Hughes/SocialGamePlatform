using Microsoft.AspNet.Identity;
using SocialGamePlatform.Models;
using SocialGamePlatform.Models.PostModels;
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
    public class PostController : ApiController
    {
        private PostServices CreatePostService()
        {
            if(User.Identity.GetUserId() == null)
            {
                var postService = new PostServices(default(Guid));
                return postService;
            }
            else
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var postService = new PostServices(userId);
                return postService;
            }
        }

        /// <summary>
        /// Adds a post to an account
        /// </summary>
        [Authorize]
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreatePostService();

            if (!service.CreatePost(post))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Searches for posts by creator username
        /// </summary>
        /// <param name="userName">Username of the poster</param>
        [ResponseType(typeof(IEnumerable<PostListItem>))]
        public IHttpActionResult Get(string userName)
        {
            PostServices postService = CreatePostService();

            var post = postService.GetPostByUsername(userName);
            if (post != null)
            {
                return Ok(post);
            }

            return NotFound();
        }

        /// <summary>
        /// Searches for post by ID
        /// </summary>
        /// <param name="id">ID of the post</param>
        [ResponseType(typeof(IEnumerable<PostListItem>))]
        public IHttpActionResult Get(int id)
        {
            PostServices postService = CreatePostService();

            var post = postService.GetPostByID(id);
            if (post != null)
            {
                return Ok(post);
            }

            return NotFound();
        }

        /// <summary>
        /// Allows an account to update a post they created
        /// </summary>
        [Authorize]
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreatePostService();

            if (!service.UpdatePost(post))
            {
                return InternalServerError();
            }

            return Ok();
        }

        /// <summary>
        /// Allows an account to delete a post they created
        /// </summary>
        /// <param name="id">Id of the post to be deleted</param>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
