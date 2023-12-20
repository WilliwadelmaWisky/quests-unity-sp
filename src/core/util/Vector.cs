namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public struct Vector
    {
        public static Vector Zero { get; } = new Vector(0, 0, 0);
        public static Vector One { get; } = new Vector(1, 1, 1);


        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(double x, double y) : this(x, y, 0) { }
    }
}
