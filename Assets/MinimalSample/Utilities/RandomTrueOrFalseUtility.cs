public static class RandomTrueOrFalseUtility
{
    public static bool RandomTrueOrFalse
    {
        get
        {
            System.Random random = new();
            bool randomBool = random.Next(2) == 1;
            return randomBool;
        }
    }
}