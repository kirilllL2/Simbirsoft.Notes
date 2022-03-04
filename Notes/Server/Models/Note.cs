namespace Notes.Server.Models;

public class Note
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	public string? Content { get; set; }
	public DateTime CreationDate { get; set; }

	public Guid UserId { get; set; }
	public User? User { get; set; }
}
