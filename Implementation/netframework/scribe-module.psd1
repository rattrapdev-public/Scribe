@{ # this is a hashtable

    #Name of the module to process
    ModuleToProcess = 'scribe-module.psm1'

    # Each module has to be uniquely identified. To do that PS uses a GUID.
    # To generate a GUID, use the New-Guid cmdlet and copy the result in here
    GUID = '7801a7ff-100c-460f-8083-e0baebb9b1b1'

    # Who wrote this module
    Author = 'Matt Winger'

    # Company who made this module
    CompanyName = 'Rattrap Development'

    # Copyright
    Copyright = '(c) 2019 All rights reserved'

    # Description of the module
    Description = 'Scribe Powershell Integration'

    # Version number for the module
    ModuleVersion = '0.0.1'

    # Minimum version of PowerShell needed to run this module
    PowerShellVersion = '5.0'

    # Min version of .NET Framework required
    DotNetFrameworkVersion = '4.0'
}