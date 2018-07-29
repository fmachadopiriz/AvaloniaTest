namespace AvaloniaTest.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Linq;

    [Serializable]
    [KnownType(typeof(Key))]
    public class Keyboard : ISerializable, IEnumerable
    {
        private IList<Key> keys;

        public string Name { get; }

        public Keyboard(string name)
        {
            this.Name = name;
            this.keys = new List<Key>();
        }

        protected Keyboard(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetValue(nameof(this.Name), typeof(string)) as string;

            object[] deserializedKeys = info.GetValue(nameof(this.keys), typeof(object[])) as object[];
            keys = new List<Key>();
            // TODO: ver de usar un método de conversión -e.g. ToList- en lugar de un bucle; no encontré como
            foreach (Key key in deserializedKeys)
            {
                this.AddKey(key);
            }
        }

        public Key this[int index]
        {
            get
            {
                return keys[index];
            }
        }

        public void AddKey(Key key)
        {
            keys.Add(key);
        }

        public void RemoveKey(Key key)
        {
            keys.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return keys.GetEnumerator();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.Name), this.Name);

            object[] serializableKeys = new object[this.keys.Count];
            serializableKeys = this.keys.ToArray<object>();
            info.AddValue(nameof(this.keys), serializableKeys);
        }
    }
}