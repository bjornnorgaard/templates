[CmdletBinding()]
Param (
    [Parameter(Mandatory)]
    [string]$Name
)

Write-Host "Creating git repo with name: $Name ... "
Write-Host -NoNewline "Done"