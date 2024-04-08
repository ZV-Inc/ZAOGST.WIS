namespace ZAOGST.WIS.CustomExceptions;

public class ControlBlockNotFoundException : Exception
{
	private const string DEFAULT_MESSAGE = "Блок управления не найден.";

	public ControlBlockNotFoundException() : base(DEFAULT_MESSAGE) { }
}