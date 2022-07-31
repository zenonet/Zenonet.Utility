namespace Zenonet.Utility;

/// <summary>
/// A representation of a Type which ensures that the type derives from TBase
/// </summary>
/// <typeparam name="TBase">The base class, the type has to be assignable to</typeparam>
public class Subtype<TBase>
{
    public Type Type;

    public Subtype(Type type)
    {
        if (type.IsAssignableTo(typeof(TBase)))
        {
            Type = type;
        }
        else
        {
            throw new ArgumentException(
                $"Can't create Subtype from {type.Name}" +
                $" because it is not assignable to {typeof(TBase)}"
            );
        }
    }

    public static Subtype<TBase> Create<TType>() where TType : TBase
    {
        return new Subtype<TBase>(typeof(TType));
    } 

    public static implicit operator Type(Subtype<TBase> subtype)
    {
        return subtype.Type;
    }
}