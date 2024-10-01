function CherryPickCommits {
    param(
        [parameter(Mandatory = $true)]
        [string] $targetBranch,
        [parameter(Mandatory = $true)]
        [string[]] $commits
    )

    git checkout $targetBranch
    git pull origin $targetBranch

    foreach ($commit in $commits) {
        if (git branch --contains $commit | Select-String -Pattern $targetBranch) 
        {
            Write-Host "Commit $commit is already in $targetBranch, skipping cherry-pick."
        } 
        else 
        {
            try {
                git cherry-pick $commit
                Write-Host "Cherry - pick $commit is successful."
            }
            catch {
                Write-Host "Error Cherry picking commit $commit. Aborting cherry-picking"
                git cherry-pick --abort
                exit 1
            }
        }
    }

    Write-Host "All commits cherry-picked successfully."
}