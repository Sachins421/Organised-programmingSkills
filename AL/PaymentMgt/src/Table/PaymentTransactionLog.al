
namespace DefaultPublisher.ALProject1;
using Microsoft.Sales.Document;
table 50000 PaymentTrancsaction
{
    DataClassification = ToBeClassified;
    //TableType = c

    fields
    {
        field(1; "Document Type"; enum "Sales Document Type")
        {
            DataClassification = ToBeClassified;
        }
        field(2; "No."; Code[20])
        {
            DataClassification = CustomerContent;
        }
        field(3; "Amount to Appy"; Decimal)
        {

        }
        field(4; Source; Enum "Payment Source")
        {

        }
        field(5; "Remaining Amount"; Decimal)
        {

        }

        field(6; "File"; Blob)
        {

        }
    }

    keys
    {
        key(PK; "Document Type", "No.")
        {
            Clustered = true;
        }

        key(SK; Source)
        {

        }
    }



    fieldgroups
    {
        // Add changes to field groups here
    }

    var
        myInt: Integer;

    trigger OnInsert()
    begin

    end;

    trigger OnModify()
    begin

    end;

    trigger OnDelete()
    begin

    end;

    trigger OnRename()
    begin

    end;

    var
        SalesHeader: Record "Sales Header";

}