namespace AvaloniaTest.Models
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NextKeyboardCommand : Command, ISerializable
    {
        public string NextKeyboardName { get; }

        public NextKeyboardCommand(string keyboardName)
        {
            this.NextKeyboardName = keyboardName;
        }

        public override void Execute()
        {
            Keyboard keyboard = KeyboardFile.Instance.GetKeyboardByName(this.NextKeyboardName);
            KeyboardStack.Instance.Push(keyboard);
        }

        protected NextKeyboardCommand(SerializationInfo info, StreamingContext context)
        {
            this.NextKeyboardName = info.GetValue(nameof(this.NextKeyboardName), typeof(string)) as string;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.NextKeyboardName), this.NextKeyboardName);
        }
    }
}