page 50001 BusinessCentralPlayGround
{
    PageType = Card;
    Caption = 'Business Central Playground';
    ApplicationArea = All;
    UsageCategory = Administration;
    SourceTable = PaymentTrancsaction;

    layout
    {
        area(Content)
        {
            group(GroupName)
            {
                field("Document Type"; Rec."Document Type")
                {

                }
                field("No."; Rec."No.")
                {

                }
            }
        }
    }

    actions
    {
        
        area(Processing)
        {
            action(BusincessCentralPlayground)
            {
                trigger OnAction()
                var
                    BusincessCentralPlayground: Codeunit BusincessCentralPlayground;
                begin
                    BusincessCentralPlayground.Run();
                end;
            }
        }
    }

    var
        myInt: Integer;
}