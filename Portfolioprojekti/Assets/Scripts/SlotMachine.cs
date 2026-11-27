using UnityEngine;

public class SlotMachine
{
    private SlotReel[] reels = new SlotReel[5];

    public SlotMachine()
    {
        for (int i = 0; i < 5; i++)
        {
            reels[i] = new SlotReel(AppConstants.reelArrays[i]);
        }
    }

    public int[] SpinReels()
    {
        int[][] spinMatrix = new int[5][];
        int[] spinIndexes = new int[5];

        for (int i = 0; i < 5; i++)
        {
            int rnd = Random.Range(0, reels[i].GetLength());
            int[] result = reels[i].GetSpinResult(rnd);
            spinIndexes[i] = rnd;

            spinMatrix[i] = new int[3];

            for (int n = 0; n < 3; n++)
            {
                spinMatrix[i][n] = result[n];
            }
        }
        CheckForWins(spinMatrix);

        /*
        for (int i = 0; i < 3; i++)
        {
            for (int n = 0; n < 5; n++)
            {
                Debug.Log(spinMatrix[n][i]);
            }
        }
        */

        return spinIndexes;
    }

    public int[] ForceWin(int symbol, int inARow, int[] payline)
    {
        // create spinmatrix which has all the numbers on the top.
        // first it finds the first index with the symbol on all the reels
        // then it adds the payline matrix to the indexes.
        // then spin and calculate the wins

        int[][] spinMatrix = new int[5][];

        int[] result = new int[5];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = reels[i].GetSymbolIndex(symbol);
        }

        for (int i = 0; i < result.Length; i++)
        {
            if (i < inARow)
            {

                // not sure if this has a bug with it going over 63
                result[i] = result[i] + payline[i] - 1 < 0 ? reels[i].GetLength() - 1 : result[i] + payline[i] - 1;
            }
            else
            {
                result[i] = Random.Range(0, reels[i].GetLength());
            }

            int[] reelResult = reels[i].GetSpinResult(result[i]);

            spinMatrix[i] = new int[3];

            for (int n = 0; n < 3; n++)
            {
                spinMatrix[i][n] = reelResult[n];
            }
        }
        CheckForWins(spinMatrix);

        return result;
    }

    private void CheckForWins(int[][] spinMatrix)
    {
        foreach (int[] winline in AppConstants.paylines)
        {
            int symbol = spinMatrix[0][winline[0]];
            for (int i = 1; i < 5; i++) //starting from 1 cuz we always check the first icon in symbol
            {
                if (spinMatrix[i][winline[i]] != symbol && i >= 3)
                {
                    _WinMoney(symbol, i);
                    break;
                }
                else if (spinMatrix[i][winline[i]] == symbol && i == 4)
                {
                    _WinMoney(symbol, i + 1);
                    break;
                }
                else if (spinMatrix[i][winline[i]] != symbol)
                {
                    break;
                }
            }
        }
    }

    private int _WinMoney(int symbol, int inARow)
    {
        int amount = AppConstants.paytable[symbol, inARow - 1];
        // std::cout << "you won " << amount << std::endl;
        Debug.Log($"You won {amount} with {inARow} symbol {symbol}'s in a row");
        return amount;
    }
}
