codeunit 50001 PaymentMgt
{
    trigger OnRun()
    begin

    end;

    // [EventSubscriber(ObjectType::Table, Database::"Sales Header", 'OnAfterValidateEvent', 'Status', true, true)]
    // local procedure OnAfterStatusValidate(var Rec: Record "Sales Header"; var xRec: Record "Sales Header")
    // var
    //     PaymentTransaction: Record PaymentTransaction;
    //     MyDictionay : Dictionary of [Integer, Text];
    // begin
    //     if Rec.IsTemporary() then
    //         exit;

    //     if Rec.Status = xRec.Status then
    //         exit;

    //     if Rec.Status = Rec.Status::Open then
    //         exit;

    //     PaymentTransaction.Init();
    //     PaymentTransaction."Document No." := Rec."No.";
    //     PaymentTransaction."Customer No." := Rec."Sell-to Customer No.";
    //     PaymentTransaction."Entry Type" := 1;
    //     PaymentTransaction."External Document No." := rec."External Document No.";
    //     PaymentTransaction.Amount := Rec.Amount;
    //     PaymentTransaction.Insert();
    // end;

    procedure TestDictionay()
    var
        Customer: Record Customer;
        MyDictionay: Dictionary of [Integer, Text];
        //MyDictionay2: Dictionary of [Integer, Customer]; // Error : unknown type,  does not work with holding instantiated records
        InterList: List of [Integer];
        MyDictionalyValue: List of [Text];
        myvalue: Text;
        myvalueonlyget: Text;
        Mykeys: Text;
        MaskValue: Integer;
        counte: Integer;
        Customer2: Record Customer;

    begin
        // Each addition to the dictionary consists of a value, and its associated key. 
        // Every key in a Dictionary must be unique. A key cannot be null, but a value can be, only when the value type is a reference type.
        // Strings are the reference type
        // The Dictionary data type does not support holding instantiated records. For this purpose, use temporary tables.
        if not Customer.Get('01121212') then
            Message('cusotmer does not exist.');
        MyDictionay.Add(1, 'abc');
        MyDictionay.Add(2, 'dbf');
        MyDictionay.Add(3, 'abc');
        MyDictionay.Add(4, Customer."No.");
        //MyDictionay.Add(5,Customer); // Error : holding instantiated records

        Message('Show count : %1', format(MyDictionay.Count));
        Message('Show contain Key : %1', format(MyDictionay.ContainsKey(1)));

        if MyDictionay.Get(4, myvalue) then
            Message('Holds customer value : %1', myvalue);

        // if MyDictionay.Get(5, Customer2) then
        //     Message('Holds customer value : %1', Customer2);

        if MyDictionay.Get(1, myvalue) then
            Message('get value : %1', myvalue);

        myvalueonlyget := MyDictionay.Get(1);

        Message('myvalueonlyget: %1', myvalueonlyget);

        InterList := MyDictionay.Keys;
        foreach MaskValue in interList do begin
            counte := InterList.Get(MaskValue);
            Message('Keys in mydictionay via List : %1', counte);
        end;

        

        MyDictionay.Set(1, 'Sachin');
        if MyDictionay.Get(1, myvalue) then
            Message('New value after set function: %1', myvalue);

        MyDictionay.Set(1, 'Shukla', myvalue);
        Message('New value after set function with variable: %1', myvalue); // it will show yo the old value but will set new value

        if MyDictionay.Get(1, myvalue) then
            Message('New value after set function: %1', myvalue); // so ehre is the new value you get


        MyDictionalyValue := MyDictionay.Values; // show all the values

        foreach myvalue in MyDictionalyValue do begin
            //myvalue := MyDictionalyValue.Get(MaskValue);
            Message('Keys in mydictionay via List : %1', myvalue);
        end;
    end;

    procedure CountCharactersInCustomerName(customerName: Text; var counter: Dictionary of [Char, Integer]);
    var
        i: Integer;
        c: Integer;
    begin
        for i := 1 to StrLen(customerName) do begin
            if counter.Get(customerName[i], c) then
                counter.Set(customerName[i], c + 1)
            else
                counter.Add(customerName[i], 1);
            Message(customerName[i]);
            Message('Counter value is : %1', counter.Get(customerName[i]));
        end;
        Message(Format(counter.Values));
    end;

    procedure TestMyListFunction()
    var
        myInt: Integer;
    begin


    end;

    var
        myInt: Integer;
}