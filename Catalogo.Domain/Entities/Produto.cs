using Catalogo.Domain.Validation;
using System;

namespace Catalogo.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public Produto(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro)
        {
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public void Update(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro, int categoriaId)
        {
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3, "O nome deve ter no mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. A descrição é obrigatória");
            DomainExceptionValidation.When(descricao.Length < 5, "A descrição deve ter no mínimo 5 caracteres");
            DomainExceptionValidation.When(preco < 0, "O valor do preço inválido");
            DomainExceptionValidation.When(imagemUrl?.Length > 250, "O nome da imagem não pode exceder 250 caracteres");
            DomainExceptionValidation.When(estoque < 0, "Estoque inválido");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImagemUrl = imagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
