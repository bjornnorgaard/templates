[CmdletBinding()]
Param (
    [Parameter(Mandatory)]
    [string]$Remote,
    [Parameter(Mandatory)]
    [string]$Name
)

Invoke-Expression "cd ..; git clone $Remote $Name"
Invoke-Expression "cd .\create-web-api"
