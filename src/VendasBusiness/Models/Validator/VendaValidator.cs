
using FluentValidation;

namespace VendasBusiness.Models.Validator
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(v => v.VendedorId)
                .NotEmpty().WithMessage("O ID do vendedor é obrigatório.");
            RuleFor(v => v.ProdutoId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");
            RuleFor(v => v.Quantidade)
                .NotEmpty().WithMessage("A quantidade vendida é obrigatória.")
                .GreaterThan(0).WithMessage("A quantidade vendida deve ser maior que zero.");
        }
    }
}
