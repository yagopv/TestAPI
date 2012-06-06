using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class CommentRepository
    {
        List<Comment> Comments = new List<Comment>()   {
                  new Comment { CommentId=1, Title = "Comment 1", Message = "Message Comment 1", Username = "user1" },
                  new Comment { CommentId=2, Title = "Comment 2", Message = "Message Comment 2", Username = "user1" },
                  new Comment { CommentId=3, Title = "Comment 3", Message = "Message Comment 3", Username = "user2" },
                  new Comment { CommentId=4, Title = "Comment 4", Message = "Message Comment 4", Username = "user2" },
                  new Comment { CommentId=5, Title = "Comment 5", Message = "Message Comment 5", Username = "user1" }
        };

        public IEnumerable<Comment> GetAllComments()
        {
            return Comments;
        }

        public Comment GetCommentByCommentId(int CommentId)
        {
            Comment Comment = Comments.Where(p => p.CommentId == CommentId).FirstOrDefault();
            return Comment ?? null;

        }

        public void AddComment(Comment Comment)
        {
            Comments.Add(Comment);
        }

        public bool DeleteComment(int CommentId)
        {
            Comment Comment = Comments.Where(p => p.CommentId == CommentId).FirstOrDefault();
            if (Comment == null)
            {
                return false;
            }
            Comments.Remove(Comment);
            return true;
        }

        public bool UpdateComment(Comment Comment)
        {
            Comment repoComment = Comments.Where(p => p.CommentId == Comment.CommentId).FirstOrDefault();
            if (repoComment == null)
            {
                return false;
            }
            repoComment.Title = Comment.Title;
            repoComment.Message = Comment.Message;

            return true;
        }
    }

}