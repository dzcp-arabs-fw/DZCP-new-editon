param(
    [string]$Version = "1.0.0",
    [string]$OutputDir = ".\packages"
)

Write-Host "Packaging DZCP version $Version"

# Create output directory
if (!(Test-Path $OutputDir)) {
    New-Item -ItemType Directory -Path $OutputDir | Out-Null
}

# Copy core files
$coreFiles = @(
    "DZCP.API.dll",
    "DZCP.Loader.dll",
    "DZCP.Events.dll"
)

foreach ($file in $coreFiles) {
    Copy-Item -Path ".\src\DZCP.API\bin\Release\net6.0\$file" -Destination $OutputDir -Force
}

# Copy dependencies
$dependencies = @(
    "YamlDotNet.dll",
    "Newtonsoft.Json.dll"
)

foreach ($dep in $dependencies) {
    Copy-Item -Path ".\src\DZCP.API\bin\Release\net6.0\$dep" -Destination $OutputDir -Force
}

# Create NuGet package
$nuspecContent = @"
<?xml version="1.0"?>
<package>
    <metadata>
        <id>DZCP.Core</id>
        <version>$Version</version>
        <authors>DZCP Team</authors>
        <description>DZCP Core Framework</description>
    </metadata>
    <files>
        <file src="*.dll" target="lib\net6.0" />
    </files>
</package>
"@

Set-Content -Path "$OutputDir\DZCP.Core.nuspec" -Value $nuspecContent
nuget pack "$OutputDir\DZCP.Core.nuspec" -OutputDirectory $OutputDir

Write-Host "Packaging completed. Files available in $OutputDir"