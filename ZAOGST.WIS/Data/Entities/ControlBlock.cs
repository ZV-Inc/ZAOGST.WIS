namespace ZAOGST.WIS.Data.Entities;

public class ControlBlock : BaseEntity
{
	public int Number { get; set; } = 0;
	public string Type { get; set; } = ControlBlockTypes.TYPE130;
	public virtual ICollection<Ballon>? Ballons { get; set; } = new HashSet<Ballon>();
	public string ShippingDate { get; set; } = DateTime.Now.ToShortDateString();
}

public class ControlBlockValidator : AbstractValidator<ControlBlock>
{
	private readonly DataContext _context;

	public ControlBlockValidator(DataContext context)
	{
		_context = context;

		RuleFor(n => n.Number).Must(IsNotNegative).WithMessage("Номер блока не может быть отрицательным или нулём");
		RuleFor(n => n.Number).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(n => n.Number).Must(IsUniqueNumber).WithMessage("Блок управления с этим номером уже существует");
		//RuleFor(n => n.Ballons).Must(IsUniqueBallonsList).WithMessage("Этот баллон уже занят");
	}

	private bool IsUniqueNumber(int number)
	{
		var exist = _context.ControlBlocks.Where(x => x.Number == number).Any();
		return exist == false;
	}

	private bool IsNotNegative(int number)
	{
		if (number <= 0) return false;
		else return true;
	}

	//TODO: Make this below
	//private bool IsUniqueBallonsList(ICollection<Ballon>? ballons)
	//{
	//	var ballon = _context.Ballons.FirstOrDefault(x => x.ControlBlock != null && x.ControlBlock != null);

	//	if (ballons == null || ballons.Count < 1 || ballon == null)
	//		return true;

	//	if (ballons.Contains(ballon.Id))
	//		return false;

	//	return true;
	//}
}

public class ControlBlockTypes
{
	public const string TYPE90 = "СКП2.00.54.200-03 (90)";
	public const string TYPE130 = "СКП2.00.54.200-01 (130)";
	public const string TYPE200 = "СКП2.00.54.200-02 (200)";

	public static List<string> GetTypesValueList() => new()
	{
		TYPE130, TYPE200, TYPE90
	};
}