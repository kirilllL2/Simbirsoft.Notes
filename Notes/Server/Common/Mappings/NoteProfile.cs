using AutoMapper;

namespace Notes.Server.Common.Mappings;

public class NoteProfile : Profile
{
	public NoteProfile()
	{
		CreateMap<CreateNoteDTO, Note>()
			.ForMember(n => n.CreationDate,
				opt => opt.MapFrom(_ => DateTime.Now));

		CreateMap<Note, NoteVM>();
	}
}
