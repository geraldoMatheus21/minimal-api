using minimalapi.Dominio.Entidades;
using minimalapi.DTOs;

namespace minimalapi.Dominio.Interfaces;

public interface IAdministradorServico
{
    administrador? Login(LoginDTO loginDTO);
}