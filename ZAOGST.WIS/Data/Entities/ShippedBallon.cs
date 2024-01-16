namespace ZAOGST.WIS.Data.Entities;

public class ShippedBallon : BaseEntity
{
	public int? StrainGaugeNumber { get; set; }
	public string BallonNumber { get; set; } = BallonNumbers.NONE;
	public int? ShippedControlBlockId { get; set; }
	public virtual ShippedControlBlock? ShippedControlBlock { get; set; }

}
