namespace GeometryLibrary
{
    public class Triangles : Shapes
    {
        // private fields
        double a, b, c;

        // default construct
        public Triangles()
        {
            a = 1; b = 2; c = 3;
        }

        public Triangles(double A, double B, double C)
        {
            SideA = A; SideB = B; SideC = C;
        }

        // Свойства для сторон
        public double SideA
        {
            get { return a; }
            set { a = value; }
        }
        public double SideB
        {
            get { return b; }
            set { b = value; }
        }
        public double SideC
        {
            get { return c; }
            set { c = value; }
        }

        public override double GetArea()
        {
            // Формула Герона: Площадь треугольника через полупериметр 
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override bool IsTriangle() => true;

        public bool IsRight()
        {
            // Теорема Пифагора
            List<double> sides = [SideA, SideB, SideC];
            sides.Sort(); // сортирую для определения гипотенузы: старшее значение-она
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-6;
        }
    }
}