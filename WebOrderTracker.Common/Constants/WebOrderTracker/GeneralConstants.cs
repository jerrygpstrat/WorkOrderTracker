using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace WebOrderTracker.Common.Constants.WebOrderTracker
{
    public static class GeneralConstants
    {
        // public const string Foo = "FooValue";


        /// <summary>
        /// Gets the remote connection
        /// </summary>
        public static string RemoteDBConnection { get => ValueReader.GetConnectionStringAsync("RemoteWotConn"); }

    }

    public  class ValueReader 
    {
        public static string GetConnectionStringAsync(string key)
        {
            // 1. Specify the path to your JSON file
            string filePath = "DbConnections.json";

            // 2. Open a file stream for efficient reading
            using FileStream openStream = File.OpenRead(filePath);

            // 3. Deserialize the JSON directly from the stream into your object
            List<DbConnectionItem>? connectionItems = JsonSerializer.Deserialize<List<DbConnectionItem>>(openStream);

            if (connectionItems != null)
            {
                DbConnectionItem? connectionItem = connectionItems.FirstOrDefault( c => c.Name == key);

                if (connectionItem != null)
                {
                    return connectionItem.Value;
                }
            }

            return string.Empty;
        }

    }

}
