namespace NewFAHP
{
    public static class Numbers
    {
        public static int TSR = 0;
        public static int SES = 1;
        public static int MFR = 2;
        public static int AS = 3;
        public static int DIST = 4;
        public static int ADS = 5;
        
        public static int TS_SE = 0;
        public static int TS_MF = 1;
        public static int TS_SA = 2;
        public static int TS_LA = 3;
        public static int TS_AA = 4;

        public static int SE_MF = 5;
        public static int SE_SA = 6;
        public static int SE_LA = 7;
        public static int SE_AA = 8;
        public static int MF_SA = 9;

        public static int MF_LA = 10;
        public static int MF_AA = 11;
        public static int SA_LA = 12;
        public static int SA_AA = 13;
        public static int LA_AA = 14;


#region Alternative TFN Values
        public static (int, int, int)[,] IntegerTFNs = new (int, int, int)[,]
        {
            { (1, 1, 3), (1, 3, 5), (3, 5, 7), (5, 7, 9), (7, 9, 9)}, // diff = 2
            { (1, 1, 2), (2, 3, 4), (4, 5, 6), (6, 7, 8), (8, 9, 9)}, // diff = 1
            { (1, 1, 1), (3, 3, 3), (5, 5, 5), (7, 7, 7), (9, 9, 9)}  // diff = 0
        };

        public static (double, double, double)[,] DoubleTFNs = new (double, double, double)[,]
        {
            { (1, 1, 1.5), (1.5, 3, 4.5), (3.5, 5, 6.5), (5.5, 7, 8.5), (7.5, 9, 9)}, // diff = 1.5
            { (1, 1, 1), (2, 3, 4), (4, 5, 6), (6, 7, 8), (8, 9, 9)}, // diff = 1.0
            { (1, 1, 1), (2.5, 3, 3.5), (4.5, 5, 5.5), (6.5, 7, 7.5), (9, 9, 9)} // diff = 0.5
        };
#endregion

        

        public static int CriteriaCount = 6;
    }
}