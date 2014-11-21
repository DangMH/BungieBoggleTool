using System;
using System.IO;
using BungieBoggleTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BungieBoggleToolUnitTests
{
    [TestClass]
    public class Resources
    {
        public static string SOLUTION_TAG = "Solution";
        public static string FILE_EXTENSION = ".txt";
        public static string RESOURCES_FILEPATH = @"D:\Users\Michael\Source\Repos\BungieBoggleTool\BungieBoggleTool\BungieBoggleTool\Resources\";
        public static string SOWPODS_FILEPATH = RESOURCES_FILEPATH + @"sowpods" + FILE_EXTENSION;
        public static string OSPD_FILEPATH = RESOURCES_FILEPATH + @"ospd" + FILE_EXTENSION;
        public static string TWL_FILEPATH = RESOURCES_FILEPATH + @"TWL_2006_LENGTH" + FILE_EXTENSION;
        public static string BOGGLEGRID1_FILEPATH = RESOURCES_FILEPATH + @"boggleGrid1" + FILE_EXTENSION;
        public static string BOGGLEGRID2_FILEPATH = RESOURCES_FILEPATH + @"boggleGrid2" + FILE_EXTENSION;
        public static string GENERATED_GRID_FILEPATH = RESOURCES_FILEPATH + @"gBoggleGrid" + FILE_EXTENSION;
        public static bool GENERATE_GRID = false;
        public static int GRID_ROW_SIZE = 10;
        public static int GRID_COL_SIZE = 10;

        public static string GenerateGridSolutionFilePath(string filePath)
        {
            return filePath.Insert(filePath.Length - FILE_EXTENSION.Length, SOLUTION_TAG);
        }

        public static string GenerateGeneratedGridFilePath(int index)
        {
            return GENERATED_GRID_FILEPATH.Insert(GENERATED_GRID_FILEPATH.Length - FILE_EXTENSION.Length, index.ToString());
        }

        [TestMethod]
        public void GenerateGrid()
        {
            if (!GENERATE_GRID)
            {
                return;
            }

            int i = 0;

            while (File.Exists(GENERATED_GRID_FILEPATH.Insert(GENERATED_GRID_FILEPATH.Length - 4, i.ToString())))
            {
                ++i;
            }

            StreamWriter generatedBoggleFile = null;

            try
            {
                generatedBoggleFile = new StreamWriter(GENERATED_GRID_FILEPATH.Insert(GENERATED_GRID_FILEPATH.Length - 4, i.ToString()));
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }

            BoggleGrid newGrid = new BoggleGrid();
            newGrid.GenerateGrid(GRID_ROW_SIZE, GRID_COL_SIZE);

            generatedBoggleFile.Write(newGrid.ToFileString());
            generatedBoggleFile.Close();
        }
    }
}
