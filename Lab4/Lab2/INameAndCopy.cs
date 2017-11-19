using System;
namespace Lab4
{
    public interface INameAndCopy
    {
        string Name { get; set; }

        object DeepCopy();
    }
}
