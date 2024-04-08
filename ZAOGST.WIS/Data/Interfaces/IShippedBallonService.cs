namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedBallonService
{
	Task Create(ShippedBallon shippedBallon);
	Task Update(ShippedBallon shippedBallon, int id);
	Task Delete(int id);
	Task<ShippedBallon> GetById(int id);
	Task<ShippedBallon> GetByStrainGaugeNumber(int strainGaugeNumber);
	Task<List<ShippedBallon>> GetList();
}
