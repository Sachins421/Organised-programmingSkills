codeunit 50002 BusincessCentralPlayground
{
    var
        Text1, Text2, text3 : Text;
        Customer, Customer1 : Record Customer; // Define multiple var in single lines
    trigger OnRun()
    begin
        httpCall();
        FilterPageBuilder();
        FieldRefDataType();
        ErrorInfoDataType();
        EnumDataType();
        dialogBox();
        CallOverloadedFunction();
    end;

    local procedure httpCall()
    var
        Client: HttpClient;
        Response: HttpResponseMessage;
        Request: HttpRequestMessage;
        URL: Text;
        ResponseText: Text;
    begin
        URL := 'https://openlibrary.org/search/lists.json?q=book&limit=5&offset=0';
        Request.SetRequestUri(URL);
        if Client.Send(Request, Response) then begin
            Response.Content.ReadAs(ResponseText);
            Message(ResponseText);
        end;

    end;

    local procedure FilterPageBuilder()
    var
        varDateItem: Text[30];
        varDateRecord: Record Date;
        varFilterPageBuilder: FilterPageBuilder;
        varCount: Integer;
        varIndex: Integer;
        Customer: Record Customer;
        Item: Record Item;
        varDefaultView: Text;
    begin
        Message('----FilterPageBuilder---');
        varDateItem := 'Date record';
        varFilterPageBuilder.AddRecord(varDateItem, varDateRecord);
        varFilterPageBuilder.AddField(varDateItem, varDateRecord."Period End", '12122015D');
        varFilterPageBuilder.AddField(varDateItem, varDateRecord."Period Start");
        varFilterPageBuilder.RunModal();

        Message('---with Name---');
        varDateItem := 'Date record';
        varFilterPageBuilder.AddTable(varDateItem + ' 1', Database::Date);
        varFilterPageBuilder.AddTable(varDateItem + ' 2', Database::Date);
        varCount := varFilterPageBuilder.COUNT;
        if varCount <> 2 then
            Error('There should be two controls in FilterPageBuilder');
        for varIndex := 1 to varCount do
            Message('Control item %1 is named %2', varIndex, varFilterPageBuilder.Name(varIndex));
        varFilterPageBuilder.RunModal();

        Message('---with Page caption---');
        varFilterPageBuilder.AddRecord('Item Table', Item);
        varFilterPageBuilder.Addfield('Item Table', Item."No.", '>100');
        varFilterPageBuilder.PageCaption := 'Item Filter Page';
        varFilterPageBuilder.RunModal;
        Item.SetView(varFilterPageBuilder.Getview('Item Table'));

        Message('---veiw of the filter page builder---');
        varDateItem := 'Date record';
        varDateRecord.SetFilter("Period End", '20151212D');
        varDateRecord.SetFilter("Period Start", '20150101D');
        varDefaultView := varDateRecord.GetView;
        varFilterPageBuilder.AddTable(varDateItem, Database::Date);
        varFilterPageBuilder.SetView(varDateItem, varDefaultView);
        varFilterPageBuilder.RunModal();
    end;


    local procedure FieldRefDataType()
    var
        RecRef: RecordRef;
        fieldRef: FieldRef;
        i: Integer;
    begin
        Message('---fieldRef----');
        RecRef.Open(Database::Customer);
        fieldRef := RecRef.Field(1);
        fieldRef.SetRange(30000);
        RecRef.Find('-');
        for i := 1 to 5 do begin
            fieldRef := RecRef.FieldIndex(i);
            //fieldRef.CalcField();
            if fieldRef.Active then
                Message('acitve %1', i)
            else
                Message('not active %1', i);
        end;
        //other method of field ref are know 
    end;

    local procedure ErrorInfoDataType()
    var
        myInt: Integer;
        ErrorInfoVar: ErrorInfo;
        Customer: Record Customer;
    begin
        Message('--ErrorInfoDataType----');

        //Creates a new ErrorInfo object with Collectible set to true.
        ErrorInfoVar := ErrorInfo.Create('Error Info is being tested', true, Customer, 1);
        Message('Errorinfor Create Method %1', ErrorInfoVar);
        Clear(ErrorInfoVar);

        //add action method
        ErrorInfoVar.ErrorType(ErrorType::Client);
        ErrorInfoVar.Verbosity(Verbosity::Error);
        ErrorInfoVar.Message('Message was added to Errorinfor variable');
        ErrorInfoVar.RecordId(Customer.RecordId);
        ErrorInfoVar.AddAction('Addaction Method', Codeunit::PaymentMgt, 'ErrorInfoMethod', 'Description is added in Addaction method');
        Message('callstask %1', ErrorInfoVar.Callstack);
        Error(ErrorInfoVar);
    end;

    local procedure EnumDataType()
    var
        EnumDataType: Enum "Sales Document Type";
        EnumReturnValue: Integer;
        EnumNames: List of [Text];
        Ordinals: List of [Integer];
        i: Integer;
    begin
        Message('---EnumDataType----');
        EnumReturnValue := EnumDataType.AsInteger();
        Message('Enum as integer %1', EnumReturnValue);

        EnumNames := EnumDataType.Names;
        for i := 0 to EnumNames.Count do begin
            Message('Enum datatype Name', EnumNames.Get(i));
        end;
        Ordinals := EnumDataType.Ordinals;
        for i := 0 to Ordinals.Count do begin
            Message('Ordinals %1', Ordinals.Get(i));
        end;
    end;

    local procedure dialogBox()
    var
        dialogReturnValue: Boolean;
    begin
        dialogReturnValue := Dialog.Confirm('Exit without saving %1?', true, '1546546');
        Message('You selected %1', dialogReturnValue);
        //TransactionType only support Report and Xmlport.
    end;

    local procedure DatabaseDatatype()
    var
        RecRef: RecordRef;
        KeyRef: KeyRef;
    begin
        RecRef.Open(50000);
        KeyRef := RecRef.KeyIndex(2);
        Message('is key enabled :%1', KeyRef.Active);
        Message('no. of fields %1 defined in current key', KeyRef.FieldCount);
        RecRef := KeyRef.Record();
        Message('Database Company Name %1', Database.CompanyName);

        // both are same
        //Commit();
        //Database.Commit();

        //The application object or method 'AlterKey' has scope 'OnPrem' and cannot be used for 'Extension' development.ALAL0296
        //supported only in on-prem
        //Database.AlterKey(KeyRef, false);    
        //Database.ChangeUserPassword('123','321');
        //Database.CheckLicenseFile(343543634);
    end;

    local procedure GetCompanyMethod()
    var
        CompanyName, CompanyId, CompanyURIName : text;
    begin
        Message('Company property is static/system function, no need to define datatype');
        Message('Compnay Display Name function : %1', CompanyProperty.DisplayName());
        Message('Compnay Id function %1', CompanyProperty.ID());
        Message('Company URI Name %1', CompanyProperty.UrlName());
        CompanyURIName := CompanyProperty.UrlName();
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