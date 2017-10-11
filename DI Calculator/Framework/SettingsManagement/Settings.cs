using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Calculator.Framework.SettingsManagement
{
    public interface ISettings
    {
        string UserName { get; }
    }


    internal class Settings : ISettings
    {
        public Settings(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }


}
