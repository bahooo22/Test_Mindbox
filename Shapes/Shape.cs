namespace GeometryLibrary
{
    public abstract class Shapes
    {
        // Абстрактный метод для вычисления площади
        public abstract double GetArea();

        // для compile-time
        public static double GetArea(Shapes shape) => shape.GetArea();

        // Метод для проверки на "круг"
        public virtual bool IsCircle() => false;

        // Метод для проверки на "треугольник"
        public virtual bool IsTriangle() => false;

        // Метод для проверки на "другая фигура"
        // public virtual bool AnyShape() => false;
    }
}