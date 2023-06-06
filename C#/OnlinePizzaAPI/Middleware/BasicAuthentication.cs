using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using OnlinePizzaAPI.Models;
using System.Text;

namespace OnlinePizzaAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthentication
    {
        private readonly RequestDelegate _next;
        private readonly IMongoCollection<UserCredentials> mongoCollection;

        public BasicAuthentication(RequestDelegate next, IOptions<PizzaStoreDatabaseSettings> DatabaseSetting)
        {
            _next = next;
            var mongoClient = new MongoClient(DatabaseSetting.Value.connectionString);
            var database = mongoClient.GetDatabase(DatabaseSetting.Value.databaseName);
            mongoCollection = database.GetCollection<UserCredentials>(DatabaseSetting.Value.Credentials);
        }

        // List<Dictionary<string,string>>
        public List<UserCredentials> GetUserNamePassword()
        {
            var documents = mongoCollection.Find(new BsonDocument()).ToList();
            return documents;
            
        } 

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.Length > 0 && authHeader.StartsWith("Basic"))      
            {
                string encodedeCrdedentials = authHeader.Substring("Basic".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string UserAndPassword = encoding.GetString(Convert.FromBase64String(encodedeCrdedentials));
                int index = UserAndPassword.IndexOf(":");   
                string userName = UserAndPassword.Substring(0, index);
                string password = UserAndPassword.Substring(index+1);
                var credentials = GetUserNamePassword();
                bool IsCredentialFound = false;
                foreach(var document in credentials)
                {
                    if (userName.Equals(document.UserName) && password.Equals(document.Password))
                    {
                        IsCredentialFound = true;
                        break;
                    }
                }
                if (IsCredentialFound == true)
                {
                    await _next.Invoke(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationExtensions
    {
        public static IApplicationBuilder UseBasicAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthentication>();
        }
    }
}
