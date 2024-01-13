Set-Location $PSScriptRoot

$distFolder = ".\dist"
if (-not (Test-Path $distFolder -PathType Container)) {
	New-Item -ItemType Directory -Path $distFolder
}

$packageContents = @(".\icon.png", ".\manifest.json", ".\README.md", ".\CHANGELOG.md", ".\NoInteractDelay\bin\Release\NoInteractDelay.dll")
$outputZipPath = Join-Path $distFolder "NoInteractDelay.zip"

Compress-Archive -Path $packageContents -DestinationPath $outputZipPath -Force
