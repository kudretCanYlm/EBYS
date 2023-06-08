using FluentValidation;

namespace EBYS.BusinessLayer.Dtos.Kullanici
{
    public class UpdateKullaniciDto
    {
        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }

    public class UpdateKullaniciDtoValidation : AbstractValidator<UpdateKullaniciDto>
    {
        public UpdateKullaniciDtoValidation()
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
