using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Görev
{
	public class UpdateGorevDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public bool TamamlandiMi { get; set; }
		public Guid PersonelId { get; set; }
	}

	public class UpdateGorevDtoValidation : AbstractValidator<UpdateGorevDto>
	{
		public UpdateGorevDtoValidation()
		{
			RuleFor(x => x.Ad)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz")
				.Length(3, 50)
				.WithMessage("3-50 karakter arası girin");

			RuleFor(x => x.Aciklama)
				.NotEmpty()
				.WithMessage("Boş olamaz")
				.NotNull()
				.WithMessage("Boş olamaz");

			RuleFor(x => x.PersonelId)
				.NotEqual(Guid.Empty)
				.WithMessage("Lütfen listeden seçiniz");

			RuleFor(x => x.BaslangicTarihi)
				.NotEmpty()
				.NotNull()
				.WithMessage("boş olamaz");

			RuleFor(x => x.BitisTarihi)
				.NotEmpty()
				.NotNull()
				.WithMessage("boş olamaz");


			RuleFor(x => x.TamamlandiMi)
				.NotEmpty()
				.NotNull()
				.WithMessage("boş olamaz");
		}
	}
}