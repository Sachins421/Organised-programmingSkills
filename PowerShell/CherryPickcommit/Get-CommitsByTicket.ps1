function Get-CommitsByTicket {
    param(
        [parameter(Mandatory = $true)]
        [string] $sourceBranch,
        [parameter(Mandatory = $true)]
        [string] $ticketNo
    )

    git fetch origin
    $commits = git log origin/$sourceBranch --grep=$ticketNo --pretty=format:"%H" --reverse
    return $commits
}