using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class CommentApiController : ApiController
    {
        static CommentRepository commentrepository = new CommentRepository();

        // GET /api/commentapi
        public IEnumerable<Comment> Get()
        {
            return commentrepository.GetAllComments();
        }

        // GET /api/commentapi/5
        public Comment Get(int id)
        {
            Comment Comment = commentrepository.GetCommentByCommentId(id);
            if (Comment == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            return Comment;
        }

        // POST /api/testapi
        public HttpResponseMessage Post(Comment Comment)
        {
            commentrepository.AddComment(Comment);
            var response = Request.CreateResponse<Comment>(HttpStatusCode.Created, Comment);

            string uri = Url.Link("DefaultApi", new { CommentId = Comment.CommentId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT /api/testapi/
        public HttpResponseMessage Put(Comment comment)
        {
            var updated = commentrepository.UpdateComment(comment);
            if (!updated)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/testapi/5
        public HttpResponseMessage Delete(int id)
        {
			var deleted = commentrepository.DeleteComment(id);
            if (!deleted)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(response);
            }		
			return new HttpResponseMessage(HttpStatusCode.NoContent); 			            
        }
    }
}
