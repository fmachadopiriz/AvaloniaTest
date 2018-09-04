namespace AvaloniaTest.Models
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NextGridCommand : Command, ISerializable
    {
        public string NextGridName { get; }

        public NextGridCommand(string gridName)
        {
            this.NextGridName = gridName;
        }

        public override void Execute()
        {
            Grid grid = GridSet.Instance.GetGridByName(this.NextGridName);
            GridStack.Instance.Push(grid);
        }

        protected NextGridCommand(SerializationInfo info, StreamingContext context)
        {
            this.NextGridName = info.GetValue(nameof(this.NextGridName), typeof(string)) as string;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.NextGridName), this.NextGridName);
        }
    }
}