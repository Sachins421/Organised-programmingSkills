    //"al.codeAnalyzers": ["${AppSourceCop}","${CodeCop}"] // to set this property go to user setting json file
    //"${AppSourceCop}" :It will enable the rule from AppSourceCop json file the all 
    //the object must have affix Foo, bar.
    //"${CodeCop}" : it will impose rule for AL coding guidelines like The valid name is PaymentTrancsaction.Table.al
    // This is how you can set settings for AL compiler in user setting file
    //"al.codeAnalyzers": ["${AppSourceCop}","${CodeCop}","${PerTenantExtensionCop}","${UICop}"] 
    
    //Specifies whether the code analysis should be performed for all source files in the opened folder
    //"al.enableCodeAnalysis": true,