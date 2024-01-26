namespace ZAOGST.WIS.Data.Interfaces;

public interface IControlBlockService
{
	Task<ControlBlock?> Create(ControlBlock controlBlock);
	Task Update(ControlBlock controlBlock);
	Task Delete(int id);
	Task<ControlBlock> GetById(int id);
	Task<List<ControlBlock>> GetList();
	Task<int> GetLastNumber();
	Task<List<Ballon>?> GetBallonsList(int id);
}
