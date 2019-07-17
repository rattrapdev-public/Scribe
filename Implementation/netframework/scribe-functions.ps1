function Write-Glossary {
    Param (    
        [Parameter(Mandatory=$true, Position=0)]
        [string] $DomainAssembly,
        [Parameter(Mandatory=$true, Position=1)]
        [string] $OutputFile,
        [Parameter(Mandatory=$false, Position=2)]
        [string] $ScribeLocation = $PSScriptRoot + "/../../lib/net472/Scribe.dll",
        [Parameter(Mandatory=$false, Position=3)]
        [string] $NewtonsoftLocation = $PSScriptRoot + "/../../lib/net472/Newtonsoft.Json.dll"
    )

    Write-Host "Loading Types"
    Write-Host $NewtonsoftLocation
    Write-Host $ScribeLocation

    Add-Type -Path $NewtonsoftLocation
    Add-Type -Path $ScribeLocation

    Write-Host "Writing Glossary for " $DomainAssembly " to " $OutputFile

    [RattrapDev.Scribe.GlossaryPublisher]::WriteGlossary($DomainAssembly, $OutputFile)

    Write-Host "Done writing glossary to " $OutputFile
}