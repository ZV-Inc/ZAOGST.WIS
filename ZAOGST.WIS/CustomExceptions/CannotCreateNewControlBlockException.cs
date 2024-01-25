namespace ZAOGST.WIS.CustomExceptions;

public class CannotCreateNewControlBlockException : Exception
{
	private const string DEFAULT_MESSAGE = "Не удалось создать новый блок управления.";

	public CannotCreateNewControlBlockException() : base(DEFAULT_MESSAGE) { }
}