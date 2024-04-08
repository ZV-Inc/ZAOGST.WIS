namespace ZAOGST.WIS.Data.Entities;

public class BaseEntity
{
	public int Id { get; set; }
	public DateTime DateAdded { get; set; } = DateTimeConverter.GetNowUTC5();
	public DateTime DateUpdated { get; set; } = DateTimeConverter.GetNowUTC5();
}
