report 50000 BusinesCentralPlayReport
{
    UsageCategory = ReportsAndAnalysis;
    ApplicationArea = All;
    DefaultRenderingLayout = LayoutName;

    dataset
    {
        dataitem(DataItemName; Customer)
        {
            column(No_; "No.")
            {

            }
            column(Name; Name)
            {

            }

            trigger OnAfterGetRecord()
            var
                myInt: Integer;
            begin
                CurrentTransactionType := TransactionType::Browse;
            end;
        }
    }

    rendering
    {
        layout(LayoutName)
        {
            Type = Excel;
            LayoutFile = 'mySpreadsheet.xlsx';
        }
    }

    var
        myInt: Integer;
}