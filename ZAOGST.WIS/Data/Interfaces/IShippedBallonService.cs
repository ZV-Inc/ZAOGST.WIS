namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedBallonService
{
	List<ShippedBallon> ShippedBallons { get; set; }
	Task LoadShippedBallon();
	Task<ShippedBallon> GetSingleShippedBallonById(int id);
	Task<ShippedBallon> GetSingleShippedBallonByStrainGaugeNumber(int strainGaugeNumber);
	Task CreateShippedBallon(ShippedBallon shippedBallon);
	Task UpdateShippedBallon(ShippedBallon shippedBallon, int id);
	Task DeleteShippedBallon(int id);
	int GetLastShippedBallonNumber();
}
