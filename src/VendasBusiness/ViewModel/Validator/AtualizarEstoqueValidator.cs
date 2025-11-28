using FluentValidation;
using VendasBusiness.ViewModel.Produto;

namespace VendasBusiness.ViewModel.Validator
{
    public class AtualizarEstoqueValidator : AbstractValidator<AtualizarEstoqueViewModel>
    {
        public AtualizarEstoqueValidator()
        {
            RuleFor(e => e.CodigoProduto)
                .NotEmpty()
                .WithMessage("o código do produto é obrigatório!");
            RuleFor(e => e.Estoque)
                .NotEmpty()
                .WithMessage("A quantidade para adicionar é obrigatório!");
            RuleFor(e => e.DescricaoProduto)
                .NotEmpty()
                .WithMessage("A descrição do produto é obrigatório!");
        }
    }
}
