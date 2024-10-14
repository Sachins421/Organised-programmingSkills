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
    var
        PaymentMgt: Codeunit PaymentMgt;
    begin
        SalesHeader.CalcFields("Amount Including VAT");
        PaymentMgt.ProcessPaymentForSalesOrder(SalesHeader."No.", SalesHeader."Amount Including VAT")
    end;

    var
        myInt: Integer;
}


