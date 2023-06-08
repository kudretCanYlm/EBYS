using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Personel
{
	public class CreatePersonelDto
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public Guid SirketId { get; set; }
		public Guid DepartmanId { get; set; }
	}

	public class CreatePersonelDtoValidation : AbstractValidator<CreatePersonelDto>
	{
		public CreatePersonelDtoValidation()
		{
			RuleFor(x => x.Ad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");

			RuleFor(x => x.Soyad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");

			RuleFor(x => x.SirketId)
				.NotEqual(Guid.Empty)
				.WithMessage("Lütfen listeden seçiniz");

			RuleFor(x => x.DepartmanId)
				.NotEqual(Guid.Empty)
				.WithMessage("Lütfen listeden seçiniz");
		}
	}
}
