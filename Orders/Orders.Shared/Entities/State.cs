using Orders.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities;

public class State : IEntityWithName
{
    public int Id { get; set; }

    [Display(Name = "Estado")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    public int CountryId { get; set; }

    public Country? Country { get; set; } = null!;

    public ICollection<City>? Cities { get; set; }

    public int CitiesNumber => Cities == null ? 0 : Cities.Count;
}