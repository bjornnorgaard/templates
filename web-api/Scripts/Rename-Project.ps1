[CmdletBinding()]
Param (
    [Parameter(Mandatory)]
    [string] $NewName,
    [Parameter(Mandatory)]
    [string] $Folder
)

function Rename-Project {
    Param (
        [Parameter(Mandatory)]
        [string] $NewName,
        [Parameter(Mandatory)]
        [string] $Folder
    )
    Process {
        Foreach ($Child in Get-ChildItem -Path $Folder) {
            if ($Child -is [System.IO.DirectoryInfo]) {
                Rename-Project -NewName $NewName -Folder $Child.FullName
            }

            if ($Child -isnot [System.IO.DirectoryInfo]) {
                $RawContent = Get-Content -Path $Child.FullName -Raw
                $UpdatedContent = $RawContent -creplace 'TMP', $NewName
                Set-Content -Path $Child.FullName -Value $UpdatedContent
            }

            if ($Child.Name -like "*TMP*") {
                Rename-Item -Path $Child.FullName -NewName ($Child.Name -creplace "TMP", $NewName)
            }
        }
    }
}

Rename-Project -Folder $Folder -NewName $NewName
