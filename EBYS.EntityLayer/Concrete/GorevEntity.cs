using EBYS.EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBYS.EntityLayer.Concrete
{
	public class GorevEntity : BaseEntity
	{
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public bool TamamlandiMi { get; set; }
		public PersonelEntity Personel { get; set; }

		[ForeignKey(nameof(Personel))]
		public Guid PersonelId { get; set; }
	}
}
