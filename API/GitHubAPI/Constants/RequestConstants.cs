//RequestConstants.cs
namespace ConsumeGitHubAPI.Constants
{
    /// <summary>
    /// Constantes para requisições à API do GitHub.
    /// </summary>
    public static class RequestConstants
    {
        /// <summary>
        /// URL base da API do GitHub.
        /// </summary>
        public const string BaseUrl = "https://api.github.com";

        /// <summary>
        /// URL para listar repositórios de uma organização. Use {0} para inserir o nome da organização.
        /// </summary>
        public const string OrgRepositoriesUrl = "/orgs/{0}/repos";

        /// <summary>
        /// Nome do header User-Agent.
        /// </summary>
        public const string UserAgent = "User-Agent";

        /// <summary>
        /// Valor do header User-Agent.
        /// </summary>
        public const string UserAgentValue = "ConsumeAPI";

        /// <summary>
        /// Nome padrão da organização que será buscada na API do GitHub.
        /// </summary>
        public const string DefaultOrgName = "takenet";

        /// <summary>
        /// Quantidade padrão de repositórios que será trazido na requisição.
        /// </summary>
        public const string DefaultPerPage = "5";

        /// <summary>
        /// Campo padrão para ordenar os repositórios.
        /// </summary>
        public const string DefaultSort = "created";

        /// <summary>
        /// Direção padrão da ordenação (ascendente ou descendente).
        /// </summary>
        public const string DefaultDirection = "asc"; // asc=ascendente || desc=descendente
    }
}
