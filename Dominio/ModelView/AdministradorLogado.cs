using minimal_api.Dominio.Enuns;

namespace minimalapi.Dominio.ModelView;

public record AdministradorLogado{
    public string Email {get; set; } = default!;
    public Perfil Perfil{get; set; } = default!;
    public string Token{ get; set; } = default!;
}