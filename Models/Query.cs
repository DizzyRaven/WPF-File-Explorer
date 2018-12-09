using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject.Models
{
    public class Query : INotifyPropertyChanged
    {
        public int QueryId { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
