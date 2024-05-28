using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPass
{
    public class AccountInfoCollection : IAccountInfoCollection
    {

        private readonly List<AccountInfo> _accountInfos;

        public string Name { get; set ; }

        public List<AccountInfo> AccountInfos => _accountInfos;

        public AccountInfoCollection(string name)
        {
            Name = name;
            _accountInfos = new List<AccountInfo>();
        }
    }
}
