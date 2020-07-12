using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_RhinoMocks
{
    public class DataManager
    {
        DataStore<string> _datastore;

        public DataManager()
        {
            _datastore = new DataStore<string>();
        }

        public void SetDataSource(DataStore<string> datastore)
        {
            _datastore = datastore;
        }

        public void LoadDataStore(string text)
        {
            _datastore.Item = text;
        }

        public string GetMessage()
        {
            return _datastore.Item;
        }
    }
}
