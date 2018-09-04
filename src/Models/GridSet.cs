namespace AvaloniaTest.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Runtime.Serialization.Json;

    public class GridSet
    {
        public static GridSet Instance = new GridSet();

        private GridSet()
        {
            // Intencionalmente vacío
        }

        private IList<Grid> grids = new List<Grid>();

        public void Reset()
        {
            grids.Clear();
        }

        public Grid GetGridByName(string name)
        {
            return grids.First(grid => grid.Name == name);
        }

        public Grid CreateGrid(string name)
        {
            Grid result = new Grid(name);
            this.grids.Add(result);
            return result;
        }

        public void RemoveGrid(Grid grid)
        {
            this.grids.Remove(grid);
        }

        public void SaveToStream(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Grid>));
            serializer.WriteObject(stream, this.grids);
        }

        public void LoadFromStream(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Grid>));
            this.grids = serializer.ReadObject(stream) as List<Grid>;
        }
    }
}