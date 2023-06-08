using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Departman
{
	public class CreateDepartmanDto
	{
		public string Ad { get; set; }
	}

	public class CreateDepartmanDtoValidation : AbstractValidator<CreateDepartmanDto>
	{
		public CreateDepartmanDtoValidation()
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
