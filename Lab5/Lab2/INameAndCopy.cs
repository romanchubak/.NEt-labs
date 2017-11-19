using System;
namespace Lab5
{
    public interface INameAndCopy
    {
        string Name { get; set; }

        object DeepCopy();
    }
}
