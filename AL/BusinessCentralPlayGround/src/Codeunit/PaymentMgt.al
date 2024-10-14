namespace DefaultPublisher.ALProject1;

using Microsoft.Sales.Document;
using Microsoft.Sales;
using Microsoft.Sales.Posting;
using Microsoft.Finance.GeneralLedger.Posting;
using Microsoft.Finance.GeneralLedger.Journal;
codeunit 50001 PaymentMgt
{
    trigger OnRun()
    begin

    end;

    procedure ProcessPaymentForSalesOrder(SalesOrderNo: Code[20]; OrderAmount: Decimal)
    var
    begin
        CreateAndPostGenJnlLine(SalesOrderNo, OrderAmount);
    end;

    local procedure CreateAndPostGenJnlLine(salesOrderNo: Code[20]; OrderAmount: Decimal)
    var
        GenJournalLine: Record "Gen. Journal Line";
        GenJnlPostLine: Codeunit "Gen. Jnl.-Post Line";
    begin
        GenJournalLine."Document Type" := GenJournalLine."Document Type"::Payment;
        GenJournalLine."Document No." := salesOrderNo;
        GenJournalLine."Line No." := 10000;
        GenJournalLine.Validate("Account Type", GenJournalLine."Account Type"::Customer);
        GenJournalLine.Validate(Amount, OrderAmount * -1);
        GenJournalLine.Validate("Bal. Account Type", GenJournalLine."Bal. Account Type"::"G/L Account");
        GenJournalLine.Validate("Bal. Account No.", '2910'); // can be used as setup instead harcode 

        GenJnlPostLine.RunWithCheck(GenJournalLine);
    end;

    procedure ErrorInfoMethod(ErrInfor: ErrorInfo)
    var
        myInt: Integer;
    begin
        Message('ErrorInforMethod was called');
    end;

    var
        myInt: Integer;
}