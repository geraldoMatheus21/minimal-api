using Microsoft.EntityFrameworkCore;
using minimalapi.Dominio.Entidades;
using minimalapi.Dominio;
using minimalapi.DTOs;
using minimalapi.infraestrutura.Db;
using minimalapi.Dominio.Interfaces;

namespace minimalapi.Dominio.Servico;

public class AdministradorServico : IAdministradorServico
{   
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public administrador? BuscaPorId(int id)
    {
         return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }

    public administrador Incluir(administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    public administrador? Login(LoginDTO loginDTO)
    {
       var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

       return adm;
        
    }

    public List<administrador> Todos(int? pagina)
    {
         var query = _contexto.Administradores.AsQueryable();
          int itensPorPágina = 10;

        if(pagina != null)
        {
           query = query.Skip(((int)pagina - 1) * itensPorPágina).Take(itensPorPágina); 
        }
        return query.ToList();
    }
}
