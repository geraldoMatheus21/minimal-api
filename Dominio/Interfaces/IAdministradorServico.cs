using minimalapi.Dominio.Entidades;
using minimalapi.DTOs;

namespace minimalapi.Dominio.Interfaces;

public interface IAdministradorServico
{
    administrador? Login(LoginDTO loginDTO);
    administrador Incluir(administrador administrador);
    administrador? BuscaPorId(int id);
    List<administrador> Todos(int? pagina);

} 