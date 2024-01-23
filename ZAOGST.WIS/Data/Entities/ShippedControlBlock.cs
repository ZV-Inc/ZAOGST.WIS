namespace ZAOGST.WIS.Data.Entities;

public class ShippedControlBlock : BaseEntity
{
	public int Number { get; set; } = 0;
	public string Type { get; set; } = ControlBlockTypes.TYPE130;
	public virtual ICollection<ShippedBallon>? ShippedBallons { get; set; } = new HashSet<ShippedBallon>();
	public string ShippingDate { get; set; } = string.Empty;
}
//public class ShipmentValidator : AbstractValidator<Shipment>
//{
//	private readonly DataContext _context;

//	public ShipmentValidator(DataContext context)
//	{
//		_context = context;

//		RuleFor(n => n.Number).NotEmpty().WithMessage("Поле не должно быть пустым");
//		RuleFor(n => n.Number).Must(IsUniqueNumber).WithMessage("Блок управления с этим номером уже существует");
//	}

//	private bool IsUniqueNumber(int number)
//	{
//		var exist = _context.ControlBlocks.Where(x => x.Number == number).Any();
//		return exist == false;
//	}
//}
