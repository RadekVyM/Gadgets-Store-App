using Microsoft.Maui.Controls.Shapes;

namespace GadgetStoreApp.Maui
{
    // TODO: Move this to the SimpleToolkit
    public static class PathFExtensions
    {
        public static PathF AsUniformScaledPath(this PathF path, RectF dirtyRect, float strokeWidth = 0)
        {
            var newPath = new PathF(path);
            newPath.TopLeftCornerMove(strokeWidth);

            var scale = Math.Min((dirtyRect.Width - strokeWidth) / newPath.Bounds.Width, (dirtyRect.Height - strokeWidth) / newPath.Bounds.Height);
            newPath = newPath.AsScaledPath(scale);
            newPath.CenterMove(dirtyRect, strokeWidth);

            return newPath;
        }

        public static PathF TopLeftCornerMove(this PathF path, float strokeWidth = 0)
        {
            path.Move(-path.Bounds.Left + (strokeWidth / 2f), -path.Bounds.Top + (strokeWidth / 2f));
            return path;
        }

        public static PathF CenterMove(this PathF path, RectF dirtyRect, float strokeWidth = 0)
        {
            path.TopLeftCornerMove(strokeWidth);

            float xOffset = (dirtyRect.Width / 2) - (path.Bounds.Width / 2);
            float yOffset = (dirtyRect.Height / 2) - (path.Bounds.Height / 2);

            path.Move(xOffset - (strokeWidth / 2f), yOffset - (strokeWidth / 2f));

            return path;
        }

        public static PathF ParseToPathF(this PathGeometry pathGeometry)
        {
            var path = new PathF();

            foreach (var figure in pathGeometry.Figures)
            {
                path.AppendFigure(figure);
            }

            return path;
        }


        private static PathF AppendFigure(this PathF path, PathFigure figure)
        {
            path.MoveTo((float)figure.StartPoint.X, (float)figure.StartPoint.Y);

            foreach (var segment in figure.Segments)
            {
                path.AppendSegment(segment);
            }

            if (figure.IsClosed)
                path.Close();

            return path;
        }

        private static PathF AppendSegment(this PathF path, PathSegment segment)
        {
            switch (segment)
            {
                case ArcSegment arcSegment:
                    path.AppendArcSegment(arcSegment);
                    break;
                case BezierSegment bezierSegment:
                    path.AppendBezierSegment(bezierSegment);
                    break;
                case LineSegment lineSegment:
                    path.AppendLineSegment(lineSegment);
                    break;
                case PolyBezierSegment polyBezierSegment:
                    path.AppendPolyBezierSegment(polyBezierSegment);
                    break;
                case PolyLineSegment polyLineSegment:
                    path.AppendPolyLineSegment(polyLineSegment);
                    break;
                case PolyQuadraticBezierSegment polyQuadraticBezierSegment:
                    path.AppendPolyQuadraticBezierSegment(polyQuadraticBezierSegment);
                    break;
                case QuadraticBezierSegment quadraticBezierSegment:
                    path.AppendQuadraticBezierSegment(quadraticBezierSegment);
                    break;
            }

            return path;
        }

        private static PathF AppendArcSegment(this PathF path, ArcSegment segment)
        {
            path.SVGArcTo(
                (float)segment.Size.Width,
                (float)segment.Size.Height,
                (float)segment.RotationAngle,
                segment.IsLargeArc,
                segment.SweepDirection is SweepDirection.Clockwise,
                (float)segment.Point.X,
                (float)segment.Point.Y,
                path.LastPoint.X,
                path.LastPoint.Y);
            return path;
        }

        private static PathF AppendQuadraticBezierSegment(this PathF path, QuadraticBezierSegment segment)
        {
            path.QuadTo(segment.Point1, segment.Point2);
            return path;
        }

        private static PathF AppendPolyQuadraticBezierSegment(this PathF path, PolyQuadraticBezierSegment segment)
        {
            int i = 0;

            while (i + 1 < segment.Points.Count)
            {
                var quadBezierSegment = new QuadraticBezierSegment(segment.Points[i], segment.Points[i + 1]);
                path.AppendQuadraticBezierSegment(quadBezierSegment);
                i += 2;
            }
            return path;
        }

        private static PathF AppendBezierSegment(this PathF path, BezierSegment segment)
        {
            path.CurveTo(segment.Point1, segment.Point2, segment.Point3);
            return path;
        }

        private static PathF AppendPolyBezierSegment(this PathF path, PolyBezierSegment segment)
        {
            int i = 0;

            while (i + 2 < segment.Points.Count)
            {
                var bezierSegment = new BezierSegment(segment.Points[i], segment.Points[i + 1], segment.Points[i + 2]);
                path.AppendBezierSegment(bezierSegment);
                i += 3;
            }

            return path;
        }

        private static PathF AppendLineSegment(this PathF path, LineSegment segment)
        {
            path.LineTo(segment.Point);
            return path;
        }

        private static PathF AppendPolyLineSegment(this PathF path, PolyLineSegment segment)
        {
            foreach (var point in segment.Points)
            {
                path.LineTo(point);
            }
            return path;
        }
    }
}
