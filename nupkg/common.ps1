# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (

    "src/EasyAbp.SharedResources.Application",
    "src/EasyAbp.SharedResources.Application.Contracts",
    "src/EasyAbp.SharedResources.Domain",
    "src/EasyAbp.SharedResources.Domain.Shared",
    "src/EasyAbp.SharedResources.EntityFrameworkCore",
    "src/EasyAbp.SharedResources.HttpApi",
    "src/EasyAbp.SharedResources.HttpApi.Client",
    "src/EasyAbp.SharedResources.MongoDB",
    "src/EasyAbp.SharedResources.Web"
)