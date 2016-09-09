namespace FinalLab
{
    public class Constants
    {
        public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
        public static string RootDir = @"D:\files\";
        public static string XmlPricesDirPath = $@"{RootDir}\Prices\";
        public static string XmlPricesFullDirPath = $@"{RootDir}\PricesFull\";
        public static string XmlStoresDirPath = $@"{RootDir}\Stores\";
        public static int XmlFilesNumber = 1;
        public static string Currency = "NIS";
        public static int CostProximity = 2;

    }
}
