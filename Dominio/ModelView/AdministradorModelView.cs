using minimal_api.Dominio.Enuns;

namespace minimalapi.Dominio.ModelView;

public record AdministradorModelView{
    public int Id {get; set; } = default!;
    public string Email {get; set; } = default!;
    public Perfil Perfil{get; set; } = default!;
}