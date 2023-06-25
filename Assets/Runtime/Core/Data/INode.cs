﻿using System;
using System.Collections.Generic;

namespace JFramework.Data
{
    public interface INode<T>
    {
        INode<T> this[int i] { get; }
        IReadOnlyCollection<INode<T>> Children { get; }
        INode<T> Parent { get; }
        T Value { get; }

        INode<T> AddChild(T value);
        INode<T>[] AddChildren(params T[] values);
        IEnumerable<T> Flatten();
        bool RemoveChild(INode<T> node);
        void Traverse(Action<T> action);
    }
}