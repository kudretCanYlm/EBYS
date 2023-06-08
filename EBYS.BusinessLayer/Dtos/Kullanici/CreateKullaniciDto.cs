using EBYS.EntityLayer.Concrete;
using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Kullanici
{
	public class CreateKullaniciDto
	{
		public string Ad { get; set; }
		public string KullaniciAdi { get; set; }
		public string Sifre { get; set; }
		public RoleEnum Role { get; set; }
	}

	public class CreateKullaniciDtoValidation : AbstractValidator<CreateKullaniciDto>
	{
		public CreateKullaniciDtoValidation()
		{
			RuleFor(x => x.Ad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");

			RuleFor(x => x.KullaniciAdi)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz");

			RuleFor(x => x.Sifre)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(5, 50)
				.WithMessage("5-50 karakter arası girin");

		}
	}
}
