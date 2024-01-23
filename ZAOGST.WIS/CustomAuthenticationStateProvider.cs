using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ZAOGST.WIS;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
	private readonly ILocalStorageService _localService;
	private readonly ProtectedSessionStorage _sessionStorage;
	private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
	private readonly HttpClient _http;

	public CustomAuthenticationStateProvider(ILocalStorageService localService, ProtectedSessionStorage sessionStorage, HttpClient http)
	{
		_localService = localService;
		_sessionStorage = sessionStorage;
		_http = http;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		try
		{
			ProtectedBrowserStorageResult<UserSession> userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
			UserSession? userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

			if (userSession == null)
				return await Task.FromResult(new AuthenticationState(_anonymous));

			ClaimsPrincipal claimsPrincipal = new(new ClaimsIdentity(new List<Claim>
			{
				new(ClaimTypes.Name, userSession.Username),
				new(ClaimTypes.Role, userSession.Role)
			}, "CustomAuth"));

			return await Task.FromResult(new AuthenticationState(claimsPrincipal));
		}
		catch
		{
			return await Task.FromResult(new AuthenticationState(_anonymous));
		}

		//string token = string.Empty;

		//try
		//{
		//	token = await _localService.GetItemAsStringAsync("token") ?? string.Empty;
		//}
		//catch (InvalidOperationException)
		//{
		//}

		//ClaimsIdentity identity = new();
		//_http.DefaultRequestHeaders.Authorization = null;

		//if (!string.IsNullOrEmpty(token))
		//{
		//	identity = new(ParseClaimsFromJwt(token), "jwt");
		//	_http.DefaultRequestHeaders.Authorization = new("Bearer", token.Replace("\"", ""));
		//}

		//ClaimsPrincipal user = new(identity);
		//AuthenticationState state = new(user);

		//NotifyAuthenticationStateChanged(Task.FromResult(state));

		//return state;
	}

	public async Task UpdateAuthenticationState(UserSession userSession)
	{
		ClaimsPrincipal claimsPrincipal;

		if(userSession != null)
		{
			await _sessionStorage.SetAsync("UserSession", userSession);

			claimsPrincipal = new(new ClaimsIdentity(new List<Claim>
			{
				new(ClaimTypes.Name, userSession.Username),
				new(ClaimTypes.Role, userSession.Role)
			}));
		}
		else
		{
			await _sessionStorage.DeleteAsync("UserSession");
			claimsPrincipal = _anonymous;
		}

		NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
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
