namespace ZAOGST.WIS.Data.Interfaces;

public interface IControlBlockService
{
	List<ControlBlock> ControlBlocks { get; set; }
	Task Load();
	Task<ControlBlock> GetById(int id);
	Task<ControlBlock?> Create(ControlBlock controlBlock);
	Task Update(ControlBlock controlBlock);
	Task Delete(int id);
	Task<int> GetLastNumber();
	Task<List<Ballon>?> GetBallonsList(int id);
}
