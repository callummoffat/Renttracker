using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renttracker.Services.DataServices
{
    public sealed class DataSourceUpdatedEventArgs : EventArgs
    {
        public string Source { get; }
        public Uri UriSource { get; }

        public DataSourceUpdatedEventArgs(string source)
        {
            Source = source;
        }

        public DataSourceUpdatedEventArgs(Uri source)
            : this (source.ToString())
        {
            UriSource = source;
        }
    }
}
