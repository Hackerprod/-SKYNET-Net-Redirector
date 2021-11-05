using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SKYNET.GUI
{
    [Serializable]
    public class RegistrySettings
    {
        public event EventHandler OnKeyEmpty;
        public event EventHandler<Exception> OnError;

        private RegistryKey Key;

        public RegistrySettings(string subKey)
        {
            Key = Registry.CurrentUser.OpenSubKey(subKey, true);
            if (Key == null)
            {
                OnKeyEmpty?.Invoke(this, new EventArgs());
                Registry.CurrentUser.CreateSubKey(subKey);
                Key = Registry.CurrentUser.OpenSubKey(subKey, true);
            }
        }
        public object Get<T>(string name, object defaultValue)
        {
            try
            {
                object Value = Key.GetValue(name);

                if (Value == null)
                {
                    Set(name, defaultValue);
                    return defaultValue;
                }

                if (typeof(T) == typeof(bool))
                {
                    return bool.Parse(Value.ToString());
                }
                if (typeof(T) == typeof(Enum))
                {
                    return (T)Value;
                }

                return Value;
            }
            catch (Exception)
            {

            }
            return defaultValue;
        }
        public void Set(string name, object val)
        {
            Key.SetValue(name, val);
            try
            {
                if (val is Enum)
                {
                    Key.SetValue(name, (int)val);
                }
                else
                    Key.SetValue(name, val);

            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex);
            }
        }
    }
}
