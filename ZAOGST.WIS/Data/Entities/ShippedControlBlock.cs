namespace ZAOGST.WIS.Data.Entities;

public class ShippedControlBlock : BaseEntity
{
	public int Number { get; set; } = 0;
	public string Type { get; set; } = ControlBlockTypes.TYPE130;
	public virtual ICollection<ShippedBallon>? ShippedBallons { get; set; } = new HashSet<ShippedBallon>();
	public string ShippingDate { get; set; } = string.Empty;
	public bool IsSended { get; set; } = false;
}