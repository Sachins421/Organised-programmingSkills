param (
    [parameter(Mandatory = $true)]
    [string] $ticketNo,
    [parameter(Mandatory = $true)]
    [string] $sourceBranch,
    [parameter(Mandatory = $true)]
    [string] $targetBranch
)

. "C:\Users\sachin.shukla\Downloads\CherryPickcommit\Get-CommitsByTicket.ps1"
. "C:\Users\sachin.shukla\Downloads\CherryPickcommit\CherryPickCommits.ps1"

cd "C:\Users\sachin.shukla\Repositories\DynamicsNAV-MSX"

$commits = Get-CommitsByTicket -sourceBranch $sourceBranch -ticketNo $ticketNo

if ($commits) {
    Write-Host "Commits found:"
    foreach ($commit in $commits) {
        Write-Host $commit
    }
} else {
    Write-Host "No commits found for ticket number $ticketNo in branch $sourceBranch."
    exit 1
}

CherryPickCommits -targetBranch $targetBranch -commits $commits