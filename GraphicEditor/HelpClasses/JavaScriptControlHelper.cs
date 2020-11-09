using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows;

namespace GraphicEditor.HelpClasses
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        Window window;
        public JavaScriptControlHelper(Window w)
        {
            window = w;
        }

        public void RunFromJavascript(string param)
        {
        }
    }
}
