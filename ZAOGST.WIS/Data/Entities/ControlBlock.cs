namespace ZAOGST.WIS.Data.Entities;

public class ControlBlock : BaseEntity
{
	public int Number { get; set; } = 0;
	public string Type { get; set; } = ControlBlockTypes.TYPE130;
	public virtual ICollection<Ballon>? Ballons { get; set; } = new HashSet<Ballon>(7);
	public string ShippingDate { get; set; } = string.Empty;
}

public class ControlBlockValidator : AbstractValidator<ControlBlock>
{
	private readonly DataContext _context;

	public ControlBlockValidator(DataContext context)
	{
		_context = context;

		RuleFor(n => n.Number).Must(IsNotNegativeNumber).WithMessage("Номер блока не может быть отрицательным или нулём");
		RuleFor(n => n.Number).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(n => n.Number).Must(IsUniqueNumber).WithMessage("Блок управления с этим номером уже существует");
	}

	private bool IsUniqueNumber(int number)
	{
		bool exist = _context.ControlBlocks.Where(x => x.Number == number).Any();
		return exist == false;
	}

	private bool IsNotNegativeNumber(int number)
	{
		if (number <= 0)
			return false;
		else
			return true;
	}
}

public class ControlBlockTypes
{
	public const string TYPE90 = "СКП2.00.54.200-03 (90)";
	public const string TYPE130 = "СКП2.00.54.200-01 (130)";
	public const string TYPE200 = "СКП2.00.54.200-02 (200)";

	public static readonly ImmutableArray<string> TypesList = new()
	{
		TYPE130, TYPE200, TYPE90
	};
}