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
        }
    }

    var
        APIManagement: Codeunit "API Management";
}