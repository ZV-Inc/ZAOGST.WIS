namespace ZAOGST.WIS.Data.Entities;

public class BaseEntity
{
	public int Id { get; set; }
	public DateTime DateAdded { get; set; } = DateTimeConverter.GetConvertedGPT5(DateTime.Now);
	public DateTime DateUpdated { get; set; } = DateTimeConverter.GetConvertedGPT5(DateTime.Now);
}
