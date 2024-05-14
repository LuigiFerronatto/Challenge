// GitHubController.cs
using ConsumeGitHubAPI.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConsumeGitHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Construtor da classe GitHubController
        public GitHubController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        /// <summary>
        /// Retorna repositórios de organizações do GitHub.
        /// </summary>
        /// <param name="org">O nome da organização do GitHub.</param>
        /// <param name="per_page">O número de repositórios por página.</param>
        /// <param name="sort">O campo para ordenar os repositórios por.</param>
        /// <param name="direction">A direção da ordenação (asc ou desc).</param>
        /// <returns>Uma lista de repositórios do GitHub.</returns>
        /// <response code="200">Retorna uma lista com os repositórios da organização.</response>
        [HttpGet("repositories")]
        [ProducesResponseType(typeof(List<GitHubRepositoryDTOs.RepositoryDTOs>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetGitHubRepositories(
            [FromQuery] string org = RequestConstants.DefaultOrgName,
            [FromQuery] string per_page = RequestConstants.DefaultPerPage,
            [FromQuery] string sort = RequestConstants.DefaultSort,
            [FromQuery] string direction = RequestConstants.DefaultDirection)
        {
            try
            {
                int perPage = int.Parse(per_page);

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

                // URL da requisição
                var requestUrl = $"https://api.github.com/orgs/{org}/repos?per_page={per_page}&sort={sort}&direction={direction}";

                // HTTP GET
                var response = await client.GetAsync(requestUrl);

                // Verifica se a requisição foi bem sucedida
                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Falha ao retornar o repositório do GitHub.");

                // Configura desserialização JSON
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var responseStream = await response.Content.ReadAsStreamAsync();
                var repositories = await JsonSerializer.DeserializeAsync<List<GitHubRepository.Models.GitHubRepository>>(responseStream, options);

                // Converte os objetos do GitHubRepository em objetos do RepositoryDTOs
                var repositoryDTOs = repositories.Select(repo => new GitHubRepositoryDTOs.RepositoryDTOs
                {
                    Id = repo.Id,
                    Name = repo.Name,
                    FullName = repo.FullName,
                    Description = repo.Description,
                    HtmlUrl = repo.HtmlUrl,
                    CreatedAt = repo.CreatedAt,
                    UpdatedAt = repo.UpdatedAt,
                    Language = repo.Language
                }).ToList();

                // Resposta HTTP OK 200 com a lista de repositórios
                return Ok(repositoryDTOs);
            }
            catch (Exception ex)
            {
                // Resposta HTTP com status 500  e uma mensagem de erro
                return StatusCode(500, $"Erro ao processar o request: {ex.Message}");
            }
        }
    }
}
