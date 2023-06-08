using EBYS.EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBYS.EntityLayer.Concrete
{
	public class PersonelEntity:BaseEntity
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public SirketEntity SirketEntity { get; set; }
		public DepartmanEntity Departman { get; set; }
		
		[ForeignKey(nameof(Departman))]
		public Guid DepartmanId { get; set; }

		[ForeignKey(nameof(SirketEntity))]
		public Guid SirketId { get; set; }
	}
}
