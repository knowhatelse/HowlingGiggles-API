using System.ComponentModel.DataAnnotations;

namespace HG.Core;

public class Post
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string PostContent { get; set; }
    public bool isDeleted { get; set; }
}
