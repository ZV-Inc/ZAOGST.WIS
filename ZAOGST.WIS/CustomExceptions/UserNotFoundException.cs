namespace ZAOGST.WIS.CustomExceptions;

public class UserNotFoundException : Exception
{
	private const string DEFAULT_MESSAGE = "Пользователь не найден.";

	public UserNotFoundException() : base(DEFAULT_MESSAGE) { }
}