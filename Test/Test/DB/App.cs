using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB
{
    class App
    {
        private static App instance;

        protected App() 
        {
            dBConnector = new DBConnector();
        }

        public static App Instance()
        {
            if(instance == null)
            {
                instance = new App();
            }
            return instance;
        }

        private DBConnector dBConnector;

        public DBConnector DBConnector
        {
            get { return dBConnector; }
            set { dBConnector = value; }
        }
    }
}
