namespace AvaloniaTest.Models
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    [KnownType(typeof(NextGridCommand))]

    public class Button : ISerializable
    {
        public string Image { get; }

        public string Text { get; }

        public Command Command { get; }

        public Button (string image, string text, Command command)
        {
            this.Image = image;
            this.Text = text;
            this.Command = command;
        }

        protected Button(SerializationInfo info, StreamingContext context)
        {
            this.Image = info.GetValue(nameof(this.Image), typeof(string)) as string;
            this.Text = info.GetValue(nameof(this.Text), typeof(string)) as string;
            this.Command = info.GetValue(nameof(this.Command), typeof(Command)) as Command;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.Image), this.Image);
            info.AddValue(nameof(this.Text), this.Text);
            info.AddValue(nameof(this.Command), this.Command);
        }
    }
}
