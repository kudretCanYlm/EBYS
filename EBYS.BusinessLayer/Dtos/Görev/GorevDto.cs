namespace EBYS.BusinessLayer.Dtos.Görev
{
	public class GorevDto
	{
		public Guid Id { get; set; }
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public bool TamamlandiMi { get; set; }
		public string PersonelAd { get; set; }
		public Guid PersonelId { get; set; }
	}
}
