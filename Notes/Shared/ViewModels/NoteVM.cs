namespace Notes.Shared.ViewModels;

public class NoteVM
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	public string? Content { get; set; }
	public DateTime CreationDate { get; set; }
}
