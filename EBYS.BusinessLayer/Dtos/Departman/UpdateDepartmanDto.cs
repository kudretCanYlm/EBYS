using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Departman
{
	public class UpdateDepartmanDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
	}

	public class UpdateDepartmanDtoValidation : AbstractValidator<UpdateDepartmanDto>
	{
		public UpdateDepartmanDtoValidation()
		{
			RuleFor(x => x.Ad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");
		}
	}
}
