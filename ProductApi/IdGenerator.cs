namespace ProductApi
{
    public static class IdGenerator
    {
        public static int Id = 0;

        public static int GetNewId()
        {
            Id++;
            return Id;
        }
    }
}
