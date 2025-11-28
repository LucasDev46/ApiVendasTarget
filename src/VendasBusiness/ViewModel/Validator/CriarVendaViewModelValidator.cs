
using FluentValidation;
using VendasBusiness.ViewModel.Venda;

namespace VendasBusiness.ViewModel.Validator
{
    public class CriarVendaViewModelValidator : AbstractValidator<CriarVendaViewModel>
    {

        public CriarVendaViewModelValidator()
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
