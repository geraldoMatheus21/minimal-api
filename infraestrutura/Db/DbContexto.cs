using Microsoft.EntityFrameworkCore;
using minimalapi.Dominio.Entidades;

namespace minimalapi.infraestrutura.Db;
public class DbContexto : DbContext
{

    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<administrador> Administradores {get; set; } = default!;

    public DbSet<Veiculos> Veiculos {get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<administrador>().HasData(
            new administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
                }
            );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
        var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
        if (!string.IsNullOrEmpty(stringConexao))
        {
            optionsBuilder.UseMySql(
                stringConexao, ServerVersion.AutoDetect(stringConexao));
        }
       }
    }
}