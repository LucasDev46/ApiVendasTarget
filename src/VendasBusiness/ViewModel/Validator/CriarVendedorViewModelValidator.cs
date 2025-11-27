

using FluentValidation;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.ViewModel.Validator
{
    public class CriarVendedorViewModelValidator : AbstractValidator<CriarVendedorViewModel>
    {
        public CriarVendedorViewModelValidator()
        {
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório!");
        }
    }
}
