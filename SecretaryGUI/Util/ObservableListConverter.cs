using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_SIMS_PROJEKAT.Util
{
    public class ObservableListConverter<T>
    {
        public ObservableCollection<T> ToObservable(List<T> list)
        {
            ObservableCollection<T> oc = new ObservableCollection<T>();
            foreach (T item in list)
            {
                oc.Add(item);
            }
            return oc;
        }
        public List<T> ToList(ObservableCollection<T> oc)
        {
            List<T> list = new List<T>();
            foreach (T item in oc)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
