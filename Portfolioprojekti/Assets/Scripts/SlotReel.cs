using UnityEngine;

public class SlotReel
{
    private int[] _reel;     
    
    public SlotReel(int[] reelArray)
    {
        _reel = reelArray;
    }
    
    public int[] Spin()
    {
        int[] result = new int[3];
        int rnd = Random.Range(0, 63);
        result[0] = _reel[rnd - 1 < 0 ? 63 : rnd - 1];
        result[1] = _reel[rnd];
        result[2] = _reel[rnd + 1 > 63 ? 0 : rnd + 1];

        return result;
    }
}
