codeunit 50000 "API Management"
{
    trigger OnRun()
    begin
        CallRestAPI();
    end;

    local procedure CallRestAPI()
    var
        TypeHelper: Codeunit "Type Helper";
        Client: HttpClient;
        Response: HttpResponseMessage;
        Request: HttpRequestMessage;
        Headers: HttpHeaders;
        ContentHeaders: HttpHeaders;
        Content: HttpContent;
        Body: Text;
        Json: JsonObject;
        AuthString: Text;
        Base64Convert: Codeunit "Base64 Convert";
        ResponseInStream: InStream;
    begin
        // Request.SetRequestUri('https://localhost:44334/api/Pizza');
        // Request.Method('GET');
        // Request.GetHeaders(Headers);
        AuthString := STRSUBSTNO('%1:%2', 'Sachin.Shukla', '123456');
        AuthString := Base64Convert.ToBase64(AuthString);
        AuthString := STRSUBSTNO('Basic %1', AuthString);
        Client.DefaultRequestHeaders.Add('Authorization', AuthString);
        Headers := Client.DefaultRequestHeaders();
        //Headers.Add('Accept', '*/*');
        /* Content.GetHeaders(ContentHeaders);
        ContentHeaders.Remove('Content-Type');
        ContentHeaders.Add('Content-Type', 'application/json');
        Request.Content := Content;  */
        if not Client.Get('https://localhost:44334/api/Pizza', Response) then
            Error('status : %1\Reason : %2', Response.HttpStatusCode, Response.ReasonPhrase);

        /*  if not Client.Send(Request, Response) then
            Error('Connection could not established.'); 
  */
        Response.Content.ReadAs(ResponseInStream);

        if Json.ReadFrom(ResponseInStream) then
            Json.WriteTo(Body);
        Message(Body);
    end;

    var
        myInt: Integer;
}