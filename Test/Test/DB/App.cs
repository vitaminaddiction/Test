using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Manager;

namespace Test.DB
{
    class App
    {
        private static App instance;

        protected App() 
        {
            dBConnector = new DBConnector();
            aPIManager = new APIManager();
            tokenManager = new TokenManager();
        }

        public static App Instance()
        {
            if(instance == null)
            {
                instance = new App();
            }
            return instance;
        }

        private APIManager aPIManager;
        private DBConnector dBConnector;
        private TokenManager tokenManager;

        public DBConnector DBConnector
        {
            get { return dBConnector; }
            set { dBConnector = value; }
        }

        public APIManager APIManager
        {
            get { return aPIManager; }
            set { aPIManager = value; }
        }
        public TokenManager TokenManager
        {
            get { return tokenManager; }
            set { tokenManager = value; }
        }

    }
}
