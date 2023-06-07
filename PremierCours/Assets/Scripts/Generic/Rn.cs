public class Rn
{
    public static uint seed;
    public static uint position;

    const uint bitNoise1 = 0x68E31DA4;
    const uint bitNoise2 = 0xB5297A4D;
    const uint bitNoise3 = 0x1B56C4E9;

    public static void SetSeed(uint newSeed)
    {
        position = 0;
        seed     = newSeed;
    }

    static uint result;

    public static uint NextUInt()
    {
        result   =  Squirrel3(position, seed);
        position += 1;
        return result;
    }

    static uint mangled;

    static uint Squirrel3(uint position, uint seed)
    {
        mangled =  position;
        mangled *= bitNoise1;
        mangled += seed;
        mangled ^= mangled >> 8;
        mangled += bitNoise2;
        mangled ^= mangled << 8;
        mangled *= bitNoise3;
        mangled ^= mangled >> 8;

        return mangled;
    }

    public static int RangeInt(int min, int max)
    {
        if (min > max)
        {
            (min, max) = (max, min);
        }

        if (min == max)
        {
            return min;
        }


        return (int)(NextUInt() % (uint)(max - min)) + min;
    }
    // return (int)(NextUInt() / (uint)(max - min + 1)) + min;

    public static float NextFloat()
    {
        return (float)NextUInt() / uint.MaxValue;
    }

    public static int RandomRangeSqrl(int min, int max)
    {
        return (int)(NextFloat() * (max - min) + min);
    }

    public static float RandomRangeSqrl(float min, float max)
    {
        return NextFloat() * (max - min) + min;
    }


    public static bool NextBool()
    {
        return NextUInt() % 2 == 0;
    }

    public static bool RandomBool(float chanceOfSuccess)
    {
        return RandomRangeSqrl(0f, 1f) <= chanceOfSuccess;
    }
}