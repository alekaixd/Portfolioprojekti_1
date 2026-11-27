using System;

public class SlotReel
{
    private int[] _reel;

    public SlotReel(int[] reelArray)
    {
        _reel = reelArray;
    }

    public int[] GetSpinResult(int reelIndex)
    {
        int[] result = new int[3];
        result[0] = _reel[reelIndex - 1 < 0 ? 63 : reelIndex - 1];
        result[1] = _reel[reelIndex];
        result[2] = _reel[reelIndex + 1 > 63 ? 0 : reelIndex + 1];

        return result;
    }

    public int GetSymbolIndex(int symbol)
    {
        return Array.IndexOf(_reel, symbol);
    }

    public int GetLength()
    {
        return _reel.Length;
    }
}
