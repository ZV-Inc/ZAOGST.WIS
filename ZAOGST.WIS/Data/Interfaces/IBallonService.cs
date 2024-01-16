namespace ZAOGST.WIS.Data.Interfaces;

public interface IBallonService
{
	List<Ballon> Ballons { get; set; }
	Task LoadBallon();
	Task<Ballon> GetSingleBallonById(int id);
	Task<Ballon> GetSingleBallonByStrainGaugeNumber(int strainGaugeNumber);
	Task CreateBallon(Ballon ballon);
	Task UpdateBallon(Ballon ballon);
	Task DeleteBallon(int id);
}
