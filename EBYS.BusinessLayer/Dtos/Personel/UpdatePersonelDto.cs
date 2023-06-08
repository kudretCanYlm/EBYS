namespace EBYS.BusinessLayer.Dtos.Personel
{
	public class UpdatePersonelDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public Guid SirketId { get; set; }
		public Guid DepartmanId { get; set; }
	}
}
