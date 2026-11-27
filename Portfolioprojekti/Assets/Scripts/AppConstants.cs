public static class AppConstants
{
    public static string[] UIReelNames = { "Reel1", "Reel2", "Reel3", "Reel4", "Reel5" };

    static private int[] reelArray1 = new int[64] {0, 4, 2, 2, 0, 3, 5, 0, 3, 1, 0, 2, 3, 2, 2, 1,
                        2, 1, 2, 4, 4, 0, 5, 0, 3, 3, 0, 1, 1, 0, 0, 3,
                        0, 2, 1, 3, 5, 1, 3, 1, 5, 1, 1, 4, 6, 3, 6, 0,
                        0, 4, 5, 6, 1, 1, 2, 4, 2, 2, 3, 0, 0, 1, 0, 1};

    static private int[] reelArray2 = new int[64] {0, 3, 4, 2, 0, 1, 2, 4, 1, 4, 1, 0, 2, 2, 3, 0,
                        1, 4, 3, 0, 4, 1, 0, 5, 0, 1, 3, 0, 0, 4, 1, 2,
                        0, 6, 1, 2, 0, 2, 1, 3, 3, 1, 3, 0, 1, 3, 5, 2,
                        2, 1, 2, 1, 5, 0, 3, 2, 0, 5, 0, 6, 3, 0, 5, 1};

    static private int[] reelArray3 = new int[64] {1, 4, 4, 1, 2, 1, 0, 1, 1, 0, 1, 6, 2, 1, 0, 0,
                        1, 5, 2, 2, 0, 0, 6, 0, 2, 3, 1, 0, 4, 0, 3, 0,
                        4, 2, 2, 3, 2, 0, 1, 0, 2, 3, 4, 3, 5, 3, 0, 5,
                        1, 0, 3, 0, 2, 1, 4, 2, 0, 0, 0, 1, 3, 3, 5, 4};

    static private int[] reelArray4 = new int[64] {4, 3, 1, 1, 2, 6, 6, 5, 4, 2, 1, 2, 1, 0, 0, 1,
                        1, 2, 1, 1, 1, 0, 5, 1, 3, 0, 2, 2, 0, 2, 0, 1,
                        1, 3, 0, 0, 1, 0, 1, 4, 6, 0, 4, 2, 0, 2, 1, 4,
                        3, 0, 3, 0, 0, 2, 4, 0, 0, 3, 5, 3, 2, 2, 3, 2};

    static private int[] reelArray5 = new int[64] {6, 2, 3, 3, 2, 1, 5, 0, 4, 5, 1, 0, 1, 4, 0, 1,
                        3, 1, 0, 3, 3, 2, 5, 0, 3, 5, 3, 1, 5, 3, 6, 2,
                        0, 2, 4, 2, 0, 2, 4, 3, 4, 3, 0, 4, 4, 0, 0, 3,
                        1, 4, 1, 1, 2, 5, 6, 1, 5, 6, 2, 0, 2, 5, 1, 4};

    static public int[][] reelArrays = new int[][] { reelArray1, reelArray2, reelArray3, reelArray4, reelArray5 };

    // 0 means top row, 1 means middle row and 2 means bottom row
    static public int[][] paylines = new int[][] {
        new int[] { 0, 0, 0, 0, 0 },
        new int[] { 1, 1, 1, 1, 1 },
        new int[] { 2, 2, 2, 2, 2 },
        new int[] { 0, 1, 2, 1, 0 },
        new int[] { 2, 1, 0, 1, 2 },
        new int[] { 0, 0, 1, 2, 2 },
        new int[] { 2, 2, 1, 0, 0 },
        new int[] { 1, 2, 2, 2, 1 },
        new int[] { 1, 0, 0, 0, 1 },
        new int[] { 2, 1, 1, 1, 0 },
        new int[] {0, 1, 1, 1, 2}};

    static public int[,] paytable = {
        {0, 0, 5, 50, 100},     {0, 0, 10, 60, 125}, {0, 0, 15, 70, 150},
        {0, 0, 20, 80, 175},    {0, 0, 25, 90, 200}, {0, 0, 50, 200, 800},
        {0, 0, 100, 500, 1000},};
}
