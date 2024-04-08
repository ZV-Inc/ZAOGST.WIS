namespace ZAOGST.WIS.CustomExceptions;

public class ShippedControlBlockNotFoundException : Exception
{
	private const string DEFAULT_MESSAGE = "Блок управления на отгрузку не найден.";

	public ShippedControlBlockNotFoundException() : base(DEFAULT_MESSAGE) { }
}
