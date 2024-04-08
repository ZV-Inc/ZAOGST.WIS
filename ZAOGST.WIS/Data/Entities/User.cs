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
		RuleFor(u => u.Username).Must(NotNullAndNotEmpty).WithMessage("Поле не должно быть пустым");
		RuleFor(u => u.Password).Must(NotNullAndNotEmpty).WithMessage("Поле не должно быть пустым");
		RuleFor(u => u.Role).Must(NotNullAndNotEmpty).WithMessage("Поле не должно быть пустым");
	}

	private bool NotNullAndNotEmpty(string str)
	{
		if (string.IsNullOrEmpty(str))
			return false;
		return true;
	}
}

public class UserRoles
{
	public const string Admin = "Администратор";
	public const string Employee = "Сотрудник";

	public static readonly List<string> RolesList = new()
	{
		Admin, Employee
	};
}