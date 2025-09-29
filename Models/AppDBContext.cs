using Microsoft.EntityFrameworkCore;

namespace Conta_Certa.Models;

public class AppDBContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Cobranca> Cobrancas { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<ServicoCobranca> ServicosCobranca {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");
        options.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // RELACIONAMENTO, CLIENTE -> COBRANCA
        modelBuilder.Entity<Cobranca>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Cobrancas)
            .HasForeignKey(c => c.DocumentoCliente)
            .HasPrincipalKey(c => c.Documento);

        // RELACIONAMENTO, COBRANCA -> SERVICOS COBRANCA
        modelBuilder.Entity<ServicoCobranca>()
            .HasOne(sc => sc.Cobranca)
            .WithMany(c => c.ServicosCobranca)
            .HasForeignKey(sc => sc.IdCobranca)
            .HasPrincipalKey(sc => sc.IdCobranca);

        // COBRANÇA UNICA
        modelBuilder.Entity<Cobranca>()
            .HasIndex(c => new { c.Vencimento, c.DocumentoCliente })
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
