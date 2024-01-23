namespace ZAOGST.WIS.Data.Entities;

public class Ballon : BaseEntity
{
	public int? StrainGaugeNumber { get; set; }
	public string BallonNumber { get; set; } = BallonNumbers.NONE;
	public string? ShippingDate { get; set; } = string.Empty;
	public int? ControlBlockId { get; set; }
	public virtual ControlBlock? ControlBlock { get; set; }
}

public class BallonValidator : AbstractValidator<Ballon>
{
	private readonly DataContext _context;

	public BallonValidator(DataContext context)
	{
		_context = context;

		RuleFor(n => n.StrainGaugeNumber).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(n => n.StrainGaugeNumber).Must(IsUniqueNumber).WithMessage("Баллон с этим номером уже существует");
		RuleFor(n => n.BallonNumber).NotNull().WithMessage("Выберите номер баллона");
	}

	private bool IsUniqueNumber(int? number)
	{
		var exist = _context.Ballons.Where(x => x.StrainGaugeNumber == number).Any();
		return exist == false;
	}
}

public class BallonNumbers
{
	public const string NONE = "Пусто";
	public const string B1_90 = "B1-90(2K)";
	public const string B2_90 = "B2-90(2K)";
	public const string B3_90 = "B3-90(2K)";
	public const string B4_90 = "B4-90(2K)";
	public const string B5_90 = "B5-90(2K)";
	public const string B1_130 = "B1-130(2K)";
	public const string B2_130 = "B2-130(2K)";
	public const string B3_130 = "B3-130(2K)";
	public const string B4_130 = "B4-130(2K)";
	public const string B5_130 = "B5-130(2K)";
	public const string B1_200 = "B1-200(2K)";
	public const string B2_200 = "B2-200(2K)";
	public const string B3_200 = "B3-200(2K)";
	public const string B4_200 = "B4-200(2K)";
	public const string B5_200 = "B5-200(2K)";
	public const string B6_200 = "B6-200(2K)";
	public const string B7_200 = "B7-200(2K)";

	public static List<string> GetProperiesList() => new()
	{
		NONE,
		B1_90,
		B2_90,
		B3_90,
		B4_90,
		B5_90,
		B1_130,
		B2_130,
		B3_130,
		B4_130,
		B5_130,
		B1_200,
		B2_200,
		B3_200,
		B4_200,
		B5_200,
		B6_200,
		B7_200
	};
}