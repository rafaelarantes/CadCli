using System;

namespace CadCliente.Domain.Cliente.Entites
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }


        public Cliente() {}

        public Cliente(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Id = Guid.NewGuid();
        }

        public int ObterIdade()
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }

        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }
    }
}
