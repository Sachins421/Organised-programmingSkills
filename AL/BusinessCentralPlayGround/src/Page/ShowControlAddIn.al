page 50000 "My Control Add In"
{
    PageType = Card;
    ApplicationArea = All;
    UsageCategory = Administration;

    layout
    {
        area(content)
        {
            usercontrol(MyControlAddIn; MyControlAddIn)
            {
                ApplicationArea = All;
                trigger MyEvent()
                begin
                    Message('Event triggered from javascript');
                end;
            }

        }

    }
}