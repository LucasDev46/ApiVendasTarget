

using FluentValidation;
using VendasBusiness.ViewModel.Produto;

namespace VendasBusiness.ViewModel.Validator
{
    public class CriarProdutoViewModelValidator : AbstractValidator<CriarProdutoViewModel>
    {

        public CriarProdutoViewModelValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório!");

            RuleFor(p => p.descricaoProduto)
                .NotEmpty()
                .WithMessage("A descrição do produto é obrigatório!");

            RuleFor(p => p.Estoque)
                .NotEmpty()
                .WithMessage("O Estoque é obrigatório!");
            RuleFor(p => p.Preco)
               .NotEmpty()
               .WithMessage("O Preço é obrigatório!");
        }
    }
}
