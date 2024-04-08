namespace ZAOGST.WIS.Data.Interfaces;

public interface IBallonService
{
	Task Create(Ballon ballon);
	Task Update(Ballon ballon);
	Task Delete(int id);
	Task<Ballon> GetById(int id);
	Task<List<Ballon>> GetList();
}
