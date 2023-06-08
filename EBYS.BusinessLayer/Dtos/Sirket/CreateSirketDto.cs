using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Sirket
{
	public class CreateSirketDto
	{
		public string Ad { get; set; }
		public string Detay { get; set; }
		public string Address { get; set; }
	}

	public class CreateSirketDtoValidation : AbstractValidator<CreateSirketDto>
	{
		public CreateSirketDtoValidation()
		{
			RuleFor(x => x.Ad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");
			RuleFor(x => x.Detay)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");

			RuleFor(x => x.Address)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");
		}
	}
}
