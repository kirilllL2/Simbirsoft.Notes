using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Server.Controllers;

[Route("api/[controller]")]
public class NotesController : BaseController 
{
	private readonly NotesDbContext _context;

	public NotesController(NotesDbContext context)
	{
		_context = context;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult<List<NoteVM>>> GetNotesByUser()
	{
		var notes = await _context.Notes
			.Where(n => n.UserId == UserId)
			.ProjectTo<NoteVM>(Mapper.ConfigurationProvider)
			.ToListAsync(CancellationToken.None);

		return Ok(notes);
	}

	[Authorize]
	[HttpGet("count")]
	public async Task<ActionResult<int>> GetCountNotesByUser()
	{
		var count = await _context.Notes
				.Where(n => n.UserId == UserId)
				.CountAsync(CancellationToken.None);

		return Ok(count);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDTO createNoteDTO)
	{
		var note = Mapper.Map<Note>(createNoteDTO);

		note.UserId = UserId;

		await _context.Notes.AddAsync(note);
		await _context.SaveChangesAsync();

		return Ok(note.Id);
	}
}
