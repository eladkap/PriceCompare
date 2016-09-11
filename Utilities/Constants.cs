namespace FinalLab
{
    public class Constants
    {
        public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
        public static string RootDir = @"D:\files\";
        public static string XmlPricesDirPath = @"D:\files\Prices\";
        public static string XmlPriceFullDirPath = @"D:\files\PriceFull\";
        public static string XmlStoresDirPath = @"D:\files\Stores\";
        public static int XmlFilesNumber = 1;
        public static string Currency = "NIS";
        public static int CostProximity = 2;
        public static int MaxStoresToUpdate = 200;
        public static int MaxItemsToUpdate = 20000;
        public static int MaxPricesToUpdate = 20000;
        public static int MaxResultsNumber = 9;
    }
}
