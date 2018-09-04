using Xunit;
using System.IO;
using System.Text;

namespace AvaloniaTest.Models.Tests
{
    public class GridFileTests
    {
        [Fact]
        public void SaveAndLoadTest()
        {
            const string gridName1 = "Grid1";
            const string gridName2 = "Grid2";
            const string buttonImage1 = "ButtonImage1";
            const string buttonImage2 = "ButtonImage2";
            const string buttonImage3 = "ButtonImage4";
            const string buttonImage4 = "ButtonImage1";
            const string buttonText1 = "ButtonText1";
            const string buttonText2 = "ButtonText2";
            const string buttonText3 = "ButtonText4";
            const string buttonText4 = "ButtonText1";

            Grid grid1 = GridSet.Instance.CreateGrid(gridName1);
            grid1.AddButton(new Button(buttonImage1, buttonText1, new NextGridCommand(gridName2)));
            grid1.AddButton(new Button(buttonImage2, buttonText2, null));

            Grid grid2 = GridSet.Instance.CreateGrid(gridName1);
            grid1.AddButton(new Button(buttonImage3, buttonText3, new NextGridCommand(gridName1)));
            grid1.AddButton(new Button(buttonImage4, buttonText4, null));

            string data;
            using (MemoryStream stream = new MemoryStream())
            {
                GridSet.Instance.SaveToStream(stream);
                byte[] json = stream.ToArray();
                stream.Close();
                data = Encoding.UTF8.GetString(json, 0, json.Length);
            }

            GridSet.Instance.Reset();

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                GridSet.Instance.LoadFromStream(stream);
                stream.Close();
            }

            Grid loadedGrid1 = GridSet.Instance.GetGridByName(gridName1);
            Assert.Equal(grid1.Name, loadedGrid1.Name);
            for (int i = 0; i < loadedGrid1.Count; i++)
            {
                // TODO: Agregar comparación de Command cuando tenga propiedades; Assert.Equal no compara objetos
                // iguales, solo idénticos.
                // Assert.Equal(grid1[i].Command, loadedGrid1[i].Command);
                Assert.Equal(grid1[i].Image, loadedGrid1[i].Image);
                Assert.Equal(grid1[i].Text, loadedGrid1[i].Text);
            }
        }

        private void AddGrid(string gridName, string nextGridName)
        {

        }
    }
}
