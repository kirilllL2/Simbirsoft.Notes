using System.ComponentModel.DataAnnotations;

namespace Notes.Shared.DataTransferObjects;

public class CreateNoteDTO
{
	[Display(Name = "Title")]
	public string? Title { get; set; }
	
	[Required]
	[Display(Name = "Text")]
	[MinLength(1, ErrorMessage = "The note must contain at least 1 character")]
	public string? Content { get; set; }
}
