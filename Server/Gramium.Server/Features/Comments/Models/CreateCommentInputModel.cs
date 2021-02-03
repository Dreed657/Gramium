namespace Gramium.Server.Features.Comments.Models
{
    public class CreateCommentInputModel
    {
        public int postId { get; set; }
        
        public string Content { get; set; }
    }
}
