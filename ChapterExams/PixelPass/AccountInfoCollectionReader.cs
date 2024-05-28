using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PixelPass
{
    public class AccountInfoCollectionReader
    {
        public static IAccountInfoCollection Read(string filename)
        {


            var lines = File.ReadAllLines(filename);

            var firstLine = lines[0];
            if (!firstLine.StartsWith("Name:"))
                throw new ParseException("The file does not start with 'Name:'.");

            var collection = new AccountInfoCollection(firstLine.Substring("Name:".Length).Trim());

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Trim();

                var parts = line.Split(',');
                if (parts.Length != 5)
                    throw new ParseException("The file format is incorrect.");

                var accountInfo = new AccountInfo
                {
                    Title = parts[0].Trim(),
                    Username = parts[1].Trim(),
                    Password = parts[2].Trim(),
                    Notes = parts[3].Trim(),
                    Expiration = Convert.ToDateTime(parts[4].Trim())
                };

                collection.AccountInfos.Add(accountInfo);
            }

            return collection;
        }
    }
}
