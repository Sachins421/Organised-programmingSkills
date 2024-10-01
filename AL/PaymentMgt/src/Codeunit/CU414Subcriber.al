namespace DefaultPublisher.ALProject1;
using Microsoft.Sales.Document;
codeunit 50000 CU414Subcriber
{
    SingleInstance = true;
    trigger OnRun()
    begin

    end;

    [EventSubscriber(ObjectType::Codeunit, Codeunit::"Release Sales Document", 'OnAfterReleaseSalesDoc', '', true, true)]
    local procedure onAfterSalesOrderRelease(SalesHeader: Record "Sales Header"; PreviewMode: Boolean; LinesWereModified: Boolean; SkipWhseRequestOperations: Boolean)
    begin

    end;

    var
        myInt: Integer;
}


