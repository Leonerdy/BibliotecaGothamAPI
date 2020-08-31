using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class Validador : AbstractValidator<SolicitacaoEmprestimo>
    {
        public Validador()
        {
            RuleFor(x => x.Nome).NotNull()
                .NotEmpty().WithMessage("Informe o seu nome")
                .Length(5, 20).WithMessage("Informe um nome com 5 e até 20 caracteres");
            RuleFor(x => x.Telefone).NotNull()
                .NotEmpty().WithMessage("Informe o telefone do usuário")
                .MinimumLength(11).WithMessage("Informe o telefone com no mínimo 11 caracteres");
            RuleFor(x => x.Livro).NotNull();
        }
    }
}
