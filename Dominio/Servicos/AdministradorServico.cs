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
    public AdministradorServico(DbContexto db)
    {
        _contexto = _contexto;
    }
    public administrador? Login(LoginDTO loginDTO)
    {
       var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

       return adm;
        
    }
}
