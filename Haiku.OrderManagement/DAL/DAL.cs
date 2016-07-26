#region Namespaces
using System.IO;
using Models;
#endregion

namespace DAL
{

    public class DAL : IDAL
    {

        public uint HRA(Customer e)
        {
            // return the same value for all contracts as per business rule. Or, return 0.
            if (File.Exists("config.data"))
            {
                var sr = new StreamReader("c:\\config.data");
                int i = sr.Read();
                return (uint)i;
            }

            return 0;
        }

    }

}
