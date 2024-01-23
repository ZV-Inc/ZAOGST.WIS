using Microsoft.AspNetCore.Server.IIS.Core;

namespace ZAOGST.WIS;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localService;

	public CustomAuthStateProvider(ILocalStorageService localService)
	{
		_localService = localService;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		string token = string.Empty;

		try
		{
			token = await _localService.GetItemAsStringAsync("token") ?? string.Empty;
		}
		catch (InvalidOperationException)
		{
		}

		ClaimsIdentity identity = new();

		if (!string.IsNullOrEmpty(token))
			identity = new(ParseClaimsFromJwt(token), "jwt");

		ClaimsPrincipal user = new(identity);
		AuthenticationState state = new(user);

		NotifyAuthenticationStateChanged(Task.FromResult(state));

		return state;
	}

	public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
	{
		var payload = jwt.Split('.')[1];
		var jsonBytes = ParseBase64WithoutPadding(payload);
		var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
		return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
	}

	private static byte[] ParseBase64WithoutPadding(string base64)
	{
		switch (base64.Length % 4)
		{
			case 2: base64 += "=="; break;
			case 3: base64 += "="; break;
		}
		return Convert.FromBase64String(base64);
	}
}
