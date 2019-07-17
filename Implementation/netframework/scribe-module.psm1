#-----------------------------------------------------------------#
# Most people though organization the functions into one or more PS1 files,
# then execute them which in turn loads them into the module
# Note your execution policy must be set appropriately to be able to do this
#-----------------------------------------------------------------#

#region Import Scripts

# $PSScriptRoot is a shortcut to "the current folder where the script is being
# run from". Also note the use of . sourcing

. $PSScriptRoot\scribe-functions.ps1

Export-ModuleMember -function Write-Glossary