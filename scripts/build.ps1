param(
    [string]$Configuration = "Release",
    [string]$OutputPath = ".\dist"
)

Write-Host "Building DZCP with configuration: $Configuration"

dotnet build .\DZCP.sln -c $Configuration

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed"
    exit 1
}

if (!(Test-Path $OutputPath)) {
    New-Item -ItemType Directory -Path $OutputPath | Out-Null
}

Copy-Item -Path ".\src\DZCP.Loader\bin\$Configuration\net6.0\*" -Destination $OutputPath -Recurse -Force
Copy-Item -Path ".\src\DZCP.API\bin\$Configuration\net6.0\*" -Destination $OutputPath -Recurse -Force

Write-Host "Build completed successfully. Output in: $OutputPath"