// RepositoryDTOs.cs
using System;

namespace GitHubRepositoryDTOs
{
    /// <summary>
    /// Objeto de Transferência de Dados (DTO) para representar um repositório do GitHub.
    /// </summary>
    public class RepositoryDTOs
    {
        /// <summary>
        /// Identificador único do repositório.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// O nome do repositório.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// O nome completo do repositório, incluindo o nome do usuário/organização.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Uma breve descrição do repositório.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// O URL para acessar o repositório no GitHub.
        /// </summary>
        public string? HtmlUrl { get; set; }

        /// <summary>
        /// A data e hora em que o repositório foi criado.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// A data e hora da última atualização do repositório.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A linguagem de programação principal do repositório.
        /// </summary>
        public string? Language { get; set; }
    }
}
