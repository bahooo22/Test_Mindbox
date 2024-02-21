using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace GeometryLibrary
{
    [TestFixture]
    public class GeometryTest
    {
        public static bool AreEqual(double expected, double actual, double epsilon) => Math.Abs(expected - actual) < epsilon;

            static List<Shapes> shapes = [new Circles(1), new Triangles(3, 4, 5), new Triangles(5,5,5)];
        static Shapes circle = new Circles(5);
        static Shapes triangle = new Triangles(3, 4, 5);

        static double[] expectedAreas = [Math.PI,6,Math.Sqrt(3)*25/4];

        
        // start tests
        public static void Run()
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                // areas
                double actualArea = shapes[i].GetArea();
                bool testResult = AreEqual(expectedAreas[i], actualArea, 1e-6);
                Console.WriteLine($"Test {i + 1}: {testResult}");

                // circles || triangles
                bool isCircle = shapes[i].IsCircle();
                bool isTriangle = shapes[i].IsTriangle();
                Console.WriteLine($"Shape {i + 1}: is circle = {isCircle}, is triangle = {isTriangle}");
                if (shapes[i].IsTriangle())
                {
                    Triangles triangle = (Triangles)shapes[i];
                    bool isRight = triangle.IsRight();
                    Console.WriteLine($"Triangle {i + 1}: is right = {isRight}");
                }
            }
            

        }

            // circle test
            [Test]
        public void TestCircleArea()
        {
            // arrange
            Circles circle = new Circles(5);
            // act
            double area = circle.GetArea();
            // assert
            ClassicAssert.AreEqual(Math.PI * 25, area, 1e-6);
        }

        // tringle test
        [Test]
        public void TestTriangleArea()
        {
            Triangles triangle = new Triangles(3, 4, 5);
            double area = triangle.GetArea();
            ClassicAssert.AreEqual(6, area, 1e-6);
        }
        // rightTriangle test
        [Test]
        public void TestIsRightTriangle()
        {
            Triangles rightTriangle = new Triangles(3, 4, 5);
            Triangles notRightTriangle = new Triangles(2, 3, 4);

            bool isRight1 = rightTriangle.IsRight();
            bool isRight2 = notRightTriangle.IsRight();

            Assert.That(isRight1, Is.True);
            Assert.That(isRight2, Is.False);
        }

        // unknown type sharp in compile-time
        [Test]
        public void TestShapeArea()
        {
            double area1 = Shapes.GetArea(circle);
            double area2 = Shapes.GetArea(triangle);
            List<double> areas = [];
            foreach (var shape in shapes)
            {
                areas.Append(shape.GetArea());
            }

            ClassicAssert.AreEqual(Math.PI * 25, area1, 1e-6);
            ClassicAssert.AreEqual(6, area2, 1e-6);
            foreach (var shape in shapes)
            {
                ClassicAssert.AreEqual(Math.PI * 25, shape.GetArea(), 1e-6);
            }
        }
    }
}
