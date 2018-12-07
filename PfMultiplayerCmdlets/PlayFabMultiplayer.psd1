#
# Module manifest for module 'PlayFabMultiplayer'
#
# Generated by: Christopher Palmer
#
# Generated on: 8/6/2018
#

@{

# Script module or binary module file associated with this manifest.
 RootModule = 'PFMultiplayerCmdlets.dll'

# Version number of this module.
ModuleVersion = '0.923'

# ID used to uniquely identify this module
GUID = '4983f215-13a8-4e0a-a26c-82278df23074'

# Author of this module
Author = 'PlayFab'

# Company or vendor of this module
CompanyName = 'Microsoft'


# Description of the functionality provided by this module
Description = 'Cmdlets that use the PlayFab Entity API (C# SDK) to manage PlayFab Game Server hosting functionality (PlayCompute)'

# Minimum version of the Windows PowerShell engine required by this module
# PowerShellVersion = ''

# Name of the Windows PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module
# DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
# CLRVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
# RequiredModules = @()

# Assemblies that must be loaded prior to importing this module
RequiredAssemblies = @("PFMultiplayerCmdlets.dll")

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @('.\NetDebug.format.ps1xml')

 #Format files (.ps1xml) to be loaded when importing this module
 FormatsToProcess = @('PlayFabMultiplayer.ps1xml')

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('.\PFMultiplayerCmdlets.dll')

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# DSC resources to export from this module
# DscResourcesToExport = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
        # Tags = @()

        # A URL to the license for this module.
        # LicenseUri = ''

        # A URL to the main website for this project.
        # ProjectUri = ''

        # A URL to an icon representing this module.
        # IconUri = ''

        # ReleaseNotes of this module
        # ReleaseNotes = ''

    } # End of PSData hashtable

} # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}