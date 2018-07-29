namespace AvaloniaTest.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.Serialization.Json;

    public class KeyboardFile
    {
        public static KeyboardFile Instance = new KeyboardFile();

        private KeyboardFile()
        {
            // Intencionalmente vacío
        }

        private IList<Keyboard> keyboards = new List<Keyboard>();

        public void Reset()
        {
            keyboards.Clear();
        }

        public Keyboard GetKeyboardByName(string name)
        {
            return keyboards.First(keyboard => keyboard.Name == name);
        }

        public void AddKeyboard(Keyboard keyboard)
        {
            this.keyboards.Add(keyboard);
        }

        public void RemoveKeyboard(Keyboard keyboard)
        {
            this.keyboards.Remove(keyboard);
        }

        public void SaveToStream(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Keyboard>));
            serializer.WriteObject(stream, this.keyboards);
        }

        public void LoadFromStream(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Keyboard>));
            this.keyboards = serializer.ReadObject(stream) as List<Keyboard>;
        }
    }
}