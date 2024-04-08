namespace ZAOGST.WIS.Data.Entities;

public class BaseEntity
{
	public int Id { get; set; }
	public DateTime DateAdded { get; set; } = DateTime.Now;
	public DateTime DateUpdated { get; set; } = DateTime.Now;
}
