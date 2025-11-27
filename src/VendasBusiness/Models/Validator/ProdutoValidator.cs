

using FluentValidation;

namespace VendasBusiness.Models.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do produto não pode exceder 100 caracteres.");
            RuleFor(p => p.Estoque)
                .NotEmpty().WithMessage("O estoque do produto é obrigatório.")
                .GreaterThanOrEqualTo(0).WithMessage("O estoque do produto não pode ser negativo.");
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("O preço do produto é obrigatório.")
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

        }
    }
}
