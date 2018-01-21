using System.Collections.Generic;
using Hackatown.Backend.Model;

namespace Hackatown.Backend
{
    public static class FakeDatabase
    {
        public static Dictionary<string, Building> Buildings { get; private set; }

        static FakeDatabase()
        {
            //Buildings = new Dictionary<string, Building>
            //{
            //    {  }
            //}
        }
    }
}