interface IVeihcle { }
class Car : IVeihcle { }
class Motocycle : IVeihcle { }

interface ICovariance<out T>
{
    T Value { get; }
}

interface IContravariante<in T>
{
    void Set(T value);
}

partial class Program
{

    ICovariance<IVeihcle> covariance = (ICovariance<Car>)null;
    IContravariante<Motocycle> contravariante = (IContravariante<IVeihcle>)null;
}