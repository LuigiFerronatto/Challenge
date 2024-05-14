Challenge API

## Overview

This project is a solution created for a challenge, implemented in C# using .NET 8. It provides an API that consumes GitHub API to request organization repositories.

## Features

- Consume GitHub API: Consumes GitHub Organization repositories.
- Request parameters: Can set up the following parameters for the GET request:
	
| Request Parameters | Options                                                 | Description                                                       |
| ------------------ | ------------------------------------------------------- | ----------------------------------------------------------------- |
| Organization       | -                                                       | Specifies the GitHub organization whose repositories to retrieve. |
| Sort               | `created`, `updated`, `pushed`, `full_name`<br><br><br> | Specifies the order in which to sort the repositories.            |
| Order              | `asc`, `desc`<br>                                       | Specifies the order in which to sort the repositories.            |
| PerPage            | Default: `30`                                           | Specifies the number of results to include per page.              |
You can view more information about **GitHub API** parameters [here](https://developer.github.com/v3/repos/#list-organization-repositories).

## Installation

To run this project locally, you need to have the following prerequisites:
- .NET 8 installed
	- [Click here to install .net 8]([Download .NET 8.0 (Linux, macOS, and Windows) (microsoft.com)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- An IDE such as Visual Studio or Visual Studio Code
	- [Click here to install VS or VSC]([Baixar Ferramentas do Visual Studio – Instalação gratuita para Windows, Mac e Linux (microsoft.com)](https://visualstudio.microsoft.com/pt-br/downloads/))

### Local Hosting

```bash
# Clone this repository to your local machine
git clone [<repository_url>](https://github.com/LuigiFerronatto/Challenge)

# Navigate to the project directory
cd <project_directory>

# Build the project
dotnet build

# Run the project
dotnet run
```

Access the API at: [localhost:7297](localhost:7297)

### Example API Request

You can make API requests using tools like curl or through the provided Swagger documentation.

```bash
curl -X 'GET' \
  'https://oqxgarggjepea43exodjyvy24a0xnnbn.lambda-url.sa-east-1.on.aws/api/GitHub/repositories?org=takenet&per_page=5&sort=created&direction=asc' \
  -H 'accept: text/plain'
```

Note: Replace ==**takenet**== with the desired organization name in the request URL. Adjust other parameters as needed.


