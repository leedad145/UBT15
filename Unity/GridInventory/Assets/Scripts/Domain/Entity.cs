using System;
using UnityEngine;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : IEquatable<TId>
{
    public TId Id { get; }

    public Entity(TId id)
    {
        Id = id;
    }

    public bool Equals(Entity<TId> other)
    {
        if (other == null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id.Equals(other.Id);
    }

    public static bool operator==(Entity<TId> left,  Entity<TId> right)
    {
        if (left is null || right is null)
        {
            return left is null && right is null;
        }

        return left.Equals(right);
    }

    public static bool operator!=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }
}