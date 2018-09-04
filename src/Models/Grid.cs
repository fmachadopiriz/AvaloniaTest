using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace AvaloniaTest.Models
{
    [Serializable]
    [KnownType(typeof(Button))]
    public class Grid : ISerializable, IEnumerable
    {
        private IList<Button> buttons;

        public string Name { get; }

        internal Grid(string name)
        {
            this.Name = name;
            this.buttons = new List<Button>();
        }

        protected Grid(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetValue(nameof(this.Name), typeof(string)) as string;

            object[] deserializedKeys = info.GetValue(nameof(this.buttons), typeof(object[])) as object[];
            buttons = new List<Button>();
            // TODO: ver de usar un método de conversión -e.g. ToList- en lugar de un bucle; no encontré como
            foreach (Button key in deserializedKeys)
            {
                this.AddButton(key);
            }
        }

        public Button this[int index]
        {
            get
            {
                return buttons[index];
            }
        }

        public int Count
        {
            get
            {
                return this.buttons.Count;
            }
        }

        public void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public void RemoveButton(Button button)
        {
            buttons.Remove(button);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return buttons.GetEnumerator();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.Name), this.Name);

            object[] serializableKeys = new object[this.buttons.Count];
            serializableKeys = this.buttons.ToArray<object>();
            info.AddValue(nameof(this.buttons), serializableKeys);
        }
    }
}