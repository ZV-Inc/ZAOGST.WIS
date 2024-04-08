namespace ZAOGST.WIS;

public static class DateTimeConverter
{
	public static DateTime GetNowUTC5() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Asia/Yekaterinburg"));
}
