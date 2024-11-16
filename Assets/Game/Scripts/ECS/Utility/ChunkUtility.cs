namespace Game.Scripts.ECS.Utility
{
    public static class ChunkUtility
    {
        public static int CountBits(int number)
        {
            var count = 0;
            
            while (number != 0)
            {
                count += number & 1;
                number >>= 1;
            }
            
            return count;
        }
    }
}