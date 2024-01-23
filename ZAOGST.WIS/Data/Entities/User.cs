namespace ZAOGST.WIS.Data.Entities;

public class User : BaseEntity
{
	public string Username { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Token { get; set; } = string.Empty;
}

public class UserValidator : AbstractValidator<User>
{
	private readonly DataContext _context;

	public UserValidator(DataContext context)
	{
		_context = context;

		RuleFor(u => u.Username).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(u => u.Password).NotEmpty().WithMessage("Поле не должно быть пустым");
	}
}