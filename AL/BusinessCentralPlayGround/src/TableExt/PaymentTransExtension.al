tableextension 50000 PaymentTranExtension extends PaymentTrancsaction
{
    fields
    {
        field(50; TextFiledExt; Text[100])
        {
            OptimizeForTextSearch = true;
        }
        field(51; Textfield2Ext; Text[100])
        {

        }
        field(52; DecimalFieldExt; Decimal)
        {

        }
    }

    keys
    {
        key(ESk; TextFiledExt)
        {
            //The Property 'IncludedFields' contains a reference to the field 'Amount to Appy' which is defined in another object from the same app. If you are preparing to move this object to another extension in the future, this reference will be an issue
            //Clustered = true;
            //IncludedFields = Textfield2Ext, "Amount to Appy"; // Amount to Apply field is from other object but can be defined
            //Primary key can not be included in IncludedFields
            IncludedFields = Textfield2Ext, DecimalFieldExt; //Sets the fields that are included as non-key columns in the index on SQL Server.
            Enabled = true; // enable or disable they key
            MaintainSiftIndex = true; // recommended for decimal field for fast calculations
            SumIndexFields = DecimalFieldExt; // list of fields 
            MaintainSqlIndex = true;

            // field in sql can not be defined if already defined in Included fields
            //SqlIndex = Textfield2Ext,DecimalFieldExt;

            //Property 'Unique' is not allowed on a table extension.
            //Unique = true; 

        }
    }

    fieldgroups
    {
        // Add changes to field groups here
    }

    var
        myInt: Integer;
}