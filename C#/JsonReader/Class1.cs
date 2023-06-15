using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace JsonReader
{
    public class DialingCodes
    {
        Dictionary<int, string> countryCodeDic = new Dictionary<int, string>();

        static Dictionary<int, string> GetEmptyDictionary() => new();

        static Dictionary<int, string> GetExistingDictionary()
        {
            var numbers = new Dictionary<int, string> { [1] = "United states Of America" };
            var id = numbers[1];
           //numbers.Values.OrderByDescending()
            return numbers;
        }

        public static void AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            
        }
    }
    public enum AccountType
    {
        Guest,
        User,
        Moderator,
        Admin
    }

    [Flags]
    public enum Permission : byte
    {
        Read = 0b00000001,
        Write = 0b00000010,
        Delete = 0b00000100,
        All = Read | Write | Delete,
        None = 0b00000000

    }

    public static class Permissions
    {
        public static Permission Default(AccountType accountType)
        {
            return accountType switch
            {
                AccountType.Guest => Permission.Read,
                AccountType.Moderator => Permission.All,
                AccountType.User => Permission.Read | Permission.Write,
                _ => Permission.None // This is the default case which will match any other AccountType values not covered by the previous cases. 
                                     //In this case, the returned Permission is Permission.None.
            };

        }

        public static Permission Grant(Permission current, Permission grant)
        {
            return current | grant;
        }

        public static Permission Revoke(Permission current, Permission revoke)
        {
            return current & ~revoke;
        }

        public static bool Check(Permission current, Permission check)
        {
            return current.HasFlag(check);
        }

    }



}
