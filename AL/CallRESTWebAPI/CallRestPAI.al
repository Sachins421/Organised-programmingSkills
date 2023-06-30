pageextension 50001 CustomerList extends "Customer List"
{
    actions
    {
        addlast(Creation)
        {
            action("Call Rest Api")
            {
                ApplicationArea = All;
                Promoted = true;
                PromotedCategory = Process;
                Caption = 'Call Rest API';
                trigger OnAction()
                begin
                    APIManagement.Run();
                end;
            }

            action("Test me")
            {
                ApplicationArea = All;
                Promoted = true;
                PromotedCategory = Process;
                Caption = 'Test me';
                trigger OnAction()
                var
                    counter: Dictionary of [Char, Integer];
                begin
                    //PaymentMgt.TestDictionay();
                    counter.Add('c', 1);
                    PaymentMgt.CountCharactersInCustomerName('Sachin', counter);
                end;

            }
        }
    }

    var
        APIManagement: Codeunit "API Management";
        PaymentMgt: Codeunit PaymentMgt;
}