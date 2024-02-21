namespace GeometryLibrary
{
    public class Circles : Shapes
    {
        /// <summary>
        /// радиус
        /// </summary>
        double r;

        public double Radius
        {
            get { return r; }
            set { r = value; }
        }

        /// <summary>
        /// Construct default
        /// </summary>
        public Circles()
        {
            Radius = 1;
        }

        public Circles(double Radius)
        {
            this.Radius = Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override bool IsCircle() => true;
    }
}
