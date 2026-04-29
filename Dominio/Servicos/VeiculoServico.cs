using Microsoft.EntityFrameworkCore;
using minimalapi.Dominio.Entidades;
using minimalapi.Dominio;
using minimalapi.DTOs;
using minimalapi.infraestrutura.Db;
using minimalapi.Dominio.Interfaces;

namespace minimalapi.Dominio.Servico;

public class VeiculoServico : IVeiculoServico
{   
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public void Apagar(Veiculos veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculos veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public Veiculos BuscaPorId(int Id)
    {
        return _contexto.Veiculos.Where(v => v.Id == Id).FirstOrDefault();
    }

    public void Incluir(Veiculos veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public List<Veiculos> Todos(int pagina = 1, string? nome = null, string marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
        }

        int itensPorPágina = 10;

        if(pagina != null)
        {
           query = query.Skip((pagina - 1) * itensPorPágina).Take(itensPorPágina); 
        }
        return query.ToList();
    }

    public List<Veiculos> Todos(int? pagina = 1, string? nome = null, string marca = null)
    {
        throw new NotImplementedException();
    }
}
