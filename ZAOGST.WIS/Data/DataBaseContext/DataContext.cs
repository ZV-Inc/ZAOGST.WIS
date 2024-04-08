namespace ZAOGST.WIS.Data.DataBaseContext;

public class DataContext : DbContext
{
	public virtual DbSet<ControlBlock> ControlBlocks { get; set; }
	public virtual DbSet<Ballon> Ballons { get; set; }
	public virtual DbSet<ShippedControlBlock> ShippedControlBlocks { get; set; }
	public virtual DbSet<ShippedBallon> ShippedBallons { get; set; }
	public virtual DbSet<User> Users { get; set; }

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ControlBlock>()
			.HasMany(cb => cb.Ballons)
			.WithOne(b => b.ControlBlock);

		modelBuilder.Entity<ShippedControlBlock>()
			.HasMany(scb => scb.ShippedBallons)
			.WithOne(sb => sb.ShippedControlBlock);
	}
}