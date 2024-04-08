namespace ZAOGST.WIS.CustomExceptions;

public class BallonNotFoundException : Exception
{
	private const string DEFAULT_MESSAGE = "Баллон не найден.";

	public BallonNotFoundException() : base(DEFAULT_MESSAGE) { }
}
