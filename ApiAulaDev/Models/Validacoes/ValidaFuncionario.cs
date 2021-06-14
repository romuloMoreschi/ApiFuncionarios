using FluentValidation;

namespace ApiAulaDev.Models.Validacoes
{
    public class ValidaFuncionario : AbstractValidator<Funcionario>
    {
        public ValidaFuncionario()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage("O sobrenome não pode ser vazio.")

                .NotNull()
                .WithMessage("O sobrenome não pode ser nulo.");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("O sobrenome não pode ser vazio.")

                .IsValidCPF()
                .WithMessage("CPF Invalido")

                .NotNull()
                .WithMessage("O sobrenome não pode ser nulo.");

            RuleFor(x => x.Credencial)
              .NotEmpty()
              .WithMessage("A credencial não pode ser vazia.")

              .NotNull()
              .WithMessage("A credencial não pode ser nula.");

            RuleFor(x => x.SetorAtuacao)
               .NotEmpty()
               .WithMessage("O setor não pode ser vazio.")

               .NotNull()
               .WithMessage("O setor não pode ser nulo.");
        }
    }
}
