using minimalapi.Dominio.Entidades;
using minimalapi.DTOs;

namespace minimalapi.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculos>Todos(int? pagina = 1, string? nome = null, string marca=null);
    Veiculos? BuscaPorId(int Id);

    void Incluir(Veiculos veiculo);
    void Atualizar(Veiculos veiculo);
    void Apagar(Veiculos veiculo);
} 