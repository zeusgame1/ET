namespace ETCold
{
    public static class Define
    {
#if UNITY_EDITOR && !ASYNC
        public static bool IsAsync = false;
#else
        public static bool IsAsync = true;
#endif



		public static bool IsILRuntime = true;

        public static int FrameRate = 60;

        public static bool IsEditor = true;




    }
}