param(
    [string]$Version = "1.0.0",
    [string]$OutputDir = ".\dist"
)

Write-Host "Building DZCP version $Version"

# Clean output directory
if (Test-Path $OutputDir) {
    Remove-Item $OutputDir -Recurse -Force
}
New-Item -ItemType Directory -Path $OutputDir | Out-Null

# Build solution
dotnet build .\DZCP.sln -c Release -p:Version=$Version

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed"
    exit 1
}

# Copy files
$projects = @(
    "DZCP.API",
    "DZCP.Loader",
    "DZCP.Events"
)

foreach ($project in $projects) {
    $source = ".\src\$project\bin\Release\net6.0\*"
    Copy-Item -Path $source -Destination $OutputDir -Recurse -Force
}

# Create archive
Compress-Archive -Path "$OutputDir\*" -DestinationPath "$OutputDir\DZCP-$Version.zip" -Force

Write-Host "Deployment package created at $OutputDir\DZCP-$Version.zip"