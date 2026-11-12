using UnityEngine;
using System.Collections.Generic;

public class ReelManager : MonoBehaviour
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

    private int[][] reelArrays = new int[][] { reelArray1, reelArray2, reelArray3, reelArray4, reelArray5 };

    public List<ReelController> reels;

    void Start()
    {
        int i = 0;
        foreach (ReelController reel in reels)
        {
            reel.iconArray = reelArrays[i];
            i++;
        }

    }

}
