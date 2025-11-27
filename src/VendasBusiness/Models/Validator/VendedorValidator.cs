

using FluentValidation;

namespace VendasBusiness.Models.Validator
{
    public class VendedorValidator : AbstractValidator<Vendedor>
    {
        public VendedorValidator()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome do vendedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do vendedor não pode exceder 100 caracteres.");
           

        }
    }
}
