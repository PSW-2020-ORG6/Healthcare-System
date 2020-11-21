using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.FrontendWrapperClasses
{
    public class ComboBoxItemWrapper<T>
    {
        private T item;

        public T Item { get => item; }

        public override string ToString()
        {
            if(Item == null || Item.Equals(DateTime.MinValue))
                {
                return "";
            }
            if(Item is DateTime)
            {
                DateTime date = DateTime.Parse(Item.ToString());
                return date.ToString("dd.MM.yyyy.");
            }
            return Item.ToString();
        }

        public override bool Equals(object obj)
        {
            ComboBoxItemWrapper<T> other = obj as ComboBoxItemWrapper<T>;
            if(other == null)
            {
                return false;
            }
            if(item != null && other.item == null)
            {
                return false;
            }
            if (item == null && other.item != null)
            {
                return false;
            }
            if(item == null && other.item == null)
            {
                return true;
            }
            return item.Equals(other.Item);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ComboBoxItemWrapper(T item)
        {
            this.item = item;
        }
    }
}
