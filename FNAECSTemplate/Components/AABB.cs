using System;
using Microsoft.Xna.Framework;

public readonly struct AABB
{
    public Vector2 Center { get; }

    public float X
    {
        get
        {
            return Center.X;
        }
    }

    public float Y
    {
        get
        {
            return Center.Y;
        }
    }

    public float Width { get; }
    public float Height { get; }
    public Vector2 TopLeft
    {
        get
        {
            return new Vector2(Center.X - Width * 0.5f, Center.Y - Height * 0.5f);
        }
    }

    public Vector2 TopRight
    {
        get
        {
            return new Vector2(Center.X + Width * 0.5f, Center.Y - Height * 0.5f);
        }
    }

    public Vector2 BottomLeft
    {
        get
        {
            return new Vector2(Center.X - Width * 0.5f, Center.Y + Height * 0.5f);
        }
    }

    public Vector2 BottomRight
    {
        get
        {
            return new Vector2(Center.X + Width * 0.5f, Center.Y + Height * 0.5f);
        }
    }

    public Vector2 Left
    {
        get
        {
            return new Vector2(Center.X - Width * 0.5f, Center.Y);
        }
    }

    public Vector2 Right
    {
        get
        {
            return new Vector2(Center.X + Width * 0.5f, Center.Y);
        }
    }

    public Vector2 Top
    {
        get
        {
            return new Vector2(Center.X, Center.Y - Height * 0.5f);
        }
    }

    public Vector2 Bottom
    {
        get
        {
            return new Vector2(Center.X, Center.Y + Height * 0.5f);
        }
    }

    public AABB(float x, float y, float w, float h)
    {
        Center = new Vector2(x, y);
        Width = w;
        Height = h;
    }

    public AABB(Vector2 position, float w, float h)
    {
        Center = position;
        Width = w;
        Height = h;
    }

    public bool Contains(Vector2 point)
    {
        return (this.Left.X <= point.X) &&
            (point.X < this.Right.X) &&
            (this.Top.Y <= point.Y) &&
            (point.Y <= this.Bottom.Y);
    }

    public AABB MinkowskiDifference(AABB other)
    {
        var mdLeft = Left - other.Right;
        var mdTop = Top - other.Bottom;
        var mdWidth = Width + other.Width;
        var mdHeight = Height + other.Height;

        var mdX = mdLeft.X + mdWidth * 0.5f;
        var mdY = mdTop.Y + mdHeight * 0.5f;

        return new AABB(mdX, mdY, mdWidth, mdHeight);
    }

    public AABB ToWorld(Vector2 position)
    {
        return new AABB(X + position.X, Y + position.Y, Width, Height);
    }

    public (Vector2 penetrationVector, bool overlaps) Overlaps(AABB other)
    {
        var md = MinkowskiDifference(other);
        var min = md.TopLeft;
        var max = md.BottomRight;

        if (min.X <= 0 && max.X >= 0 &&
            min.Y <= 0 && max.Y >= 0)
        {
            return (PenetrationVector(md), true);
        }

        return (Vector2.Zero, false);
    }

    Vector2 PenetrationVector(AABB md)
    {
        var min = md.TopLeft;
        var max = md.BottomRight;

        var minDist = MathF.Abs(min.X);
        var boundsPoint = new Vector2(min.X, 0);

        if (MathF.Abs(max.X) < minDist)
        {
            minDist = MathF.Abs(max.X);
            boundsPoint.X = max.X;
        }

        if (MathF.Abs(max.Y) < minDist)
        {
            minDist = MathF.Abs(max.Y);
            boundsPoint.X = 0;
            boundsPoint.Y = max.Y;
        }

        if (MathF.Abs(min.Y) < minDist)
        {
            boundsPoint.X = 0;
            boundsPoint.Y = min.Y;
        }

        return boundsPoint;
    }
}