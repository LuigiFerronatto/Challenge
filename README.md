
## Overview

This project is a solution created for a challenge, implemented in C# using .NET 8. It provides an API that consumes GitHub API to request organization repositories.

## Installation

To run this project locally, you need to have the following prerequisites:
- .NET 8 installed
	- [Click here to install .net 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- An IDE such as Visual Studio or Visual Studio Code
	- [Click here to install VS or VSC](https://visualstudio.microsoft.com/pt-br/downloads/)

# Local Host

#### Clone this repository to your local machine
```bash
git clone https://github.com/LuigiFerronatto/Challenge.git
```
#### Navigate to the project directory
```bash
cd Challenge
```
#### Build the project
```bash
dotnet build
```
#### Run the project
```bash
dotnet run
```

### Example API Request

You can make API requests using tools like curl or through the provided Swagger documentation.

```bash
curl -X 'GET' \
  'https://oqxgarggjepea43exodjyvy24a0xnnbn.lambda-url.sa-east-1.on.aws/api/GitHub/repositories?org=takenet&per_page=5&sort=created&direction=asc' \
  -H 'accept: text/plain'
```

Note: Replace **takenet** with the desired organization name in the request URL. Adjust other parameters as needed.

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

## Stacks

**Deploy:** AWSLambda

**Back-end:** C#, .Net8

**Dependencies:**
- Amazon.Lambda.AspNetCoreServer (v9.0.0)
- Amazon.Lambda.AspNetCoreServer.Hosting (v1.7.0)
- Amazon.Lambda.Serialization.Json (v2.2.1) 
- AWSSDK.Extensions.NETCore.Setup (v3.7.300)
- Microsoft.AspNetCore.Mvc.Abstractions (v2.2.0)
- Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer (v5.1.0)
- Microsoft.AspNetCore.OpenApi (v8.0.4) 
- Swashbuckle.AspNetCore (v6.6.1) AutoMapper (v13.0.1) 
- AutoMapper.Extensions.Microsoft.DependencyInjection (v12.0.1) 
- Swashbuckle.AspNetCore.Annotations (v6.6.1) 
- System.Net.Http.Json (v8.0.0)
