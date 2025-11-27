using FluentValidation;
using VendasBusiness.ViewModel.Vendedor;
namespace VendasBusiness.ViewModel.Validator
{
    public class AtualizarVendedorViewModelValidator : AbstractValidator<AtualizarVendedorViewModel>
    {

        public AtualizarVendedorViewModelValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .WithMessage("É necessário o ID para realizar a atualização!");
            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("O Nome é obrigatório!");
        }
    }
}
