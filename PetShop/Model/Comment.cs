namespace PetShop.Model
{
    public class Comment
    {

        public int CommentId { get; set; }

        public int AnimalId { get; set; }

        public string? CommentMessage { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
