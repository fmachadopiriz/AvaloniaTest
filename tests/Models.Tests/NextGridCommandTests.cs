using Xunit;
using System.IO;
using System.Text;
using AvaloniaTest.Models;

namespace AvaloniaTest.Models.Tests
{
    public class NextGridCommandTests
    {
        [Fact]
        public void SaveAndLoadTest()
        {
            const string gridName1 = "Grid 1";
            const string gridName2 = "Grid 2";
            Grid grid1 = GridSet.Instance.CreateGrid(gridName1);
            Grid grid2 = GridSet.Instance.CreateGrid(gridName2);
            Command command = new NextGridCommand(gridName1);
            command.Execute();
            Assert.Equal(grid2, GridStack.Instance.Peek());
        }
    }
}