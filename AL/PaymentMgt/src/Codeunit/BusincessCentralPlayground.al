codeunit 50002 BusincessCentralPlayground
{
    var
        Text1, Text2, text3 : Text;
        Customer, Customer1 : Record Customer; // Define multiple var in single lines
    trigger OnRun()
    begin

    end;

    local procedure StringBuilderFunction()
    var
        Mytext: TextBuilder;
    begin
        text1 := 'Hello';
        Mytext.Append(Text1);
        Message('Append Function :%1', Mytext.ToText());
        Mytext.Append('Newlyaddedtext');
        Message('Next append function %1:', Mytext.ToText());
        Mytext.AppendLine('Appendlind');
        Message('Appendline function %1', Mytext.ToText());

        Message('capacity funciton %1', Mytext.Capacity);
        Message('Max capacity %1', Mytext.MaxCapacity);
        Message('Ensure Capacity %1', Mytext.EnsureCapacity(20));
        Message('Insert Text %1', Mytext.Insert(1, 'PP'));
        Message('Length %1', Mytext.Length);
        Message('remove %1', Mytext.Remove(2, 1));
    end;




    local procedure CallOverloadedFunction()
    var
        myInt: Integer;
    begin
        Myfunction('Hello');
        Myfunction(Today);
        Myfunction(Random(10));
    end;

    ////Funciton overloading
    local procedure Myfunction(newText: Text)
    var
        myInt: Integer;
    begin
        Message(newText);
    end;

    local procedure Myfunction(TodayDate: Date)
    var
        myInt: Integer;
    begin
        Message('today date is %1', TodayDate);
    end;

    local procedure Myfunction(RandomNo: Integer)
    var
        myInt: Integer;
    begin
        Message('your no is :' + Format(RandomNo));
    end;

    var
        myInt: Integer;
}