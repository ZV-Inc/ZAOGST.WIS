namespace ZAOGST.WIS.Data.Interfaces;

public interface IBallonService
{
	List<Ballon> Ballons { get; set; }
	Task Load();
	Task<Ballon> GetById(int id);
	Task<Ballon> GetByStrainGaugeNumber(int strainGaugeNumber);
	Task Create(Ballon ballon);
	Task Update(Ballon ballon);
	Task Delete(int id);
}
