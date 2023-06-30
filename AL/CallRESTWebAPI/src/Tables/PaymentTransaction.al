table 50000 PaymentTransaction
{
    DataClassification = ToBeClassified;
    
    fields
    {
        field(1;"Document No."; Code[20])
        {
            DataClassification = ToBeClassified;
            
        }
        field(2;"Customer No."; Code[20])
        {
            DataClassification = ToBeClassified;
            
        }
        field(3;"Entry Type"; Integer)
        {
            DataClassification = ToBeClassified;
            
        }
        field(4;Amount; Decimal)
        {
            DataClassification = ToBeClassified;
            
        }
        field(5;"External Document No."; Code[20])
        {
            DataClassification = ToBeClassified;
            
        }


    }
    
    keys
    {
        key(Key1; "Document No.")
        {
            Clustered = true;
        }
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
    
}