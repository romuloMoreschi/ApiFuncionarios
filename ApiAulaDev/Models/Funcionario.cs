using System;
using System.Collections.Generic;
using ApiAulaDev.Models.Validacoes;
using System.ComponentModel.DataAnnotations;

namespace ApiAulaDev.Models
{
    public class Funcionario : Base
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Credencial { get; private set; }

        [Display(Name = "Setor de atuação")]
        public string SetorAtuacao { get; private set; }

        public Funcionario()
        {
        }

        public Funcionario(string nome, string sobrenome, string credencial, string setorAtuacao)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Credencial = credencial;
            SetorAtuacao = setorAtuacao;
            _errors = new List<string>();
        }

        public void TrocarNome(string nome)
        {
            Nome = nome;
            Validar();
        }
        public void TrocarSobrenome(string sobrenome)
        {
            Sobrenome = sobrenome;
            Validar();
        }
        public void TrocarCredencial(string credencial)
        {
            Credencial = credencial;
            Validar();
        }
        public void TrocarSetor(string setorAtuacao)
        {
            SetorAtuacao = setorAtuacao;
            Validar();
        }

        public override bool Validar()
        {
            var validador = new ValidaFuncionario();
            var validacao = validador.Validate(this);

            if (!validacao.IsValid)
            {
                foreach (var error in validacao.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new Exception("Alguns campos estão inválidos, por favor corrija-os!" + _errors[0]);
            }

            return true;
        }
    }
}
