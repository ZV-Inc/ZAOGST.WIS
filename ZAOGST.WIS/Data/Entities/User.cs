namespace ZAOGST.WIS.Data.Entities;

public class User : BaseEntity
{
	public string Username { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Role { get; set; } = string.Empty;
}

public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
	{
		RuleFor(u => u.Username).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(u => u.Password).NotEmpty().WithMessage("Поле не должно быть пустым");
		RuleFor(u => u.Role).NotEmpty().WithMessage("Поле не должно быть пустым");
	}
}

public class UserRoles
{
	public const string Admin = "Администратор";
	public const string Employee = "Сотрудник";

	public static readonly ImmutableArray<string> RolesList = new()
	{
		Admin, Employee
	};
}