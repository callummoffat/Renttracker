using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.DataServices
{
    public delegate void DataSourceUpdatedEventHandler(IDataService sender, DataSourceUpdatedEventArgs e);
}
