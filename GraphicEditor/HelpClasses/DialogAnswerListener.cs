using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.HelpClasses
{
    public interface DialogAnswerListener<T>
    {
        void onConfirmUpdate(T t);
    }
}
