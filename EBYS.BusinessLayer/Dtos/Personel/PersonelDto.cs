namespace EBYS.BusinessLayer.Dtos.Personel
{
	public class PersonelDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public Guid SirketId { get; set; }
		public string SirketName { get; set; }
		public Guid DepartmanId { get; set; }
		public string DepartmanName { get; set; }
	}
}
