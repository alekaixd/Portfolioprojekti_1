using UnityEngine;

public class SlotMachine
{
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

    static private int[,] winline1 = {{0, 0, 0, 0, 0}, {1, 1, 1, 1, 1}, {0, 0, 0, 0, 0}};
    static private int[,] winline2 = {{1, 1, 1, 1, 1}, {0, 0, 0, 0, 0}, {0, 0, 0, 0, 0}};
    static private int[,] winline3 = {{0, 0, 0, 0, 0}, {0, 0, 0, 0, 0}, {1, 1, 1, 1, 1}};
    static private int[,] winline4 = {{0, 0, 1, 0, 0}, {0, 1, 0, 1, 0}, {1, 0, 0, 0, 1}};
    static private int[,] winline5 = {{1, 0, 0, 0, 1}, {0, 1, 0, 1, 0}, {0, 0, 1, 0, 0}};
    static private int[,] winline6 = {{1, 1, 0, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 0, 1, 1}};
    static private int[,] winline7 = {{0, 0, 0, 1, 1}, {0, 0, 1, 0, 0}, {1, 1, 0, 0, 0}};
    static private int[,] winline8 = {{0, 0, 0, 0, 0}, {1, 0, 0, 0, 1}, {0, 1, 1, 1, 0}};
    static private int[,] winline9 = {{0, 1, 1, 1, 0}, {1, 0, 0, 0, 1}, {0, 0, 0, 0, 0}};
    static private int[,] winline10 = {{1, 0, 0, 0, 0}, {0, 1, 1, 1, 0}, {0, 0, 0, 0, 1}};
    static private int[,] winline11 = {{0, 0, 0, 0, 1}, {0, 1, 1, 1, 0}, {1, 0, 0, 0, 0}};
    
    static private int[,] paytable = {
    {0, 0, 5, 50, 100},     {0, 0, 10, 60, 125}, {0, 0, 15, 70, 150},
    {0, 0, 20, 80, 175},    {0, 0, 25, 90, 200}, {0, 0, 50, 200, 800},
    {0, 0, 100, 500, 1000},};

    private int[][] _reelArrays = new int[][] { reelArray1, reelArray2, reelArray3, reelArray4, reelArray5 };
    private SlotReel[] reels = new SlotReel[5];
    
    private int[][,] _winlines = {winline1, winline2, winline3, winline4, winline5, winline6, winline7, winline8, winline9, winline10, winline11};

    public SlotMachine()
    {
        for (int i = 0; i < 5; i++)
        {
            reels[i] = new SlotReel(_reelArrays[i]);
        }
    }

    public void SpinReels()
    {
        int[][] spinMatrix = new int[5][];
        
        
        for (int i = 0; i < 5; i++) 
        {
            int[] result = reels[i].Spin();
            spinMatrix[i] = new int[3];
            
            for (int n = 0; n < 3; n++) {
                spinMatrix[i][n] = result[n];
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            for (int n = 0; n < 5; n++)
            {
                Debug.Log(spinMatrix[n][i]);
            }
        }
    }
}
