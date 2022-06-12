pageextension 50100 MyIPAddress extends "Customer List"
{
    actions
    {
        addlast(Creation)
        {
            action("Get my IDP Adress")
            {
                ApplicationArea = All;
                Promoted = true;
                PromotedCategory = Process;
                Caption = 'Get my IDP Adress';
                trigger OnAction()
                begin
                    Message('Your IP address is %1', GetIPAddress);
                end;
            }
        }
    }
    local procedure GetIPAddress(): Text;
        var
            Client: HttpClient;
            Response: HttpResponseMessage;
            JObject: JsonObject;
            ResponseText: Text;
        begin
            //https://api.ipify.org?format=json
            if Client.Get('https://api.ipify.org?format=json',Response) then
                if Response.IsSuccessStatusCode() then begin
                    if Response.Content.ReadAs(ResponseText) then
                        Jobject.ReadFrom(ResponseText);
                        exit(GetJsonValue(JObject,'ip'));
                end;
        end;

    local procedure GetJsonValue(JObject: JsonObject; KeyText: Text): Text;
    var
        Result: JsonToken;
    begin
        if JObject.get(KeyText, Result) then
            exit(Result.AsValue.AsText());
    end;

    var
        myInt: Integer;
}