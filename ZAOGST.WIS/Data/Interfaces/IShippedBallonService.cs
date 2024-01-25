namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedBallonService
{
	List<ShippedBallon> ShippedBallons { get; set; }
	Task Load();
	Task<ShippedBallon> GetById(int id);
	Task<ShippedBallon> GetByStrainGaugeNumber(int strainGaugeNumber);
	Task Create(ShippedBallon shippedBallon);
	Task Update(ShippedBallon shippedBallon, int id);
	Task Delete(int id);
}
