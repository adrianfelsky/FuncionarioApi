using System.ComponentModel.DataAnnotations;

namespace _04_Domain.Entities;

public class Funcionario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O cargo é obrigatório.")]
    public string Cargo { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
    public decimal Salario { get; set; }

    [Required(ErrorMessage = "O departamento é obrigatório.")]
    public string Departamento { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;
}