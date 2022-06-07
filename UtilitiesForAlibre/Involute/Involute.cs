using System;
using System.Collections.Generic;
using AlibreX;

namespace Bolsover.Involute
{
    public class Involute
    {
        private InvoluteProperties properties;

        // Lists of points representing the involute curves.
        // Note that first and last points are also used to anchor the addendum and dedendum points.
        private List<List<Point>> pointsListR = new();
        private List<List<Point>> pointsListL = new();

        public Involute(InvoluteProperties properties)
        {
            this.properties = properties;
        }

        public InvoluteProperties Properties
        {
            get => properties;
            set => properties = value;
        }

        public void DrawGear2()
        {
            var sketch = createSketch();
            sketch.BeginChange();
            // Draw reference circles
            DrawReferenceCircles(sketch);
            // Draws involute curves and populates the lists of points pointsListR and pointsListL.
            DrawInvoluteCurves(sketch);
            if (properties.DedendumCircleDiameter <= properties.BaseCircleDiameter)
            {
                DrawDedendumToBaseCircleLines(sketch);
                DrawDedendumArcs(sketch);
            }
            else
            {
                DrawDedendumArcs(sketch);
            }

            DrawAddedendumArcs(sketch);
            sketch.EndChange();
        }


        private void DrawDedendumArcs(IADSketch sketch)
        {
            var centre = new Point(properties.WheelCentreX, properties.WheelCentreY);

            if (properties.DedendumCircleDiameter <= properties.BaseCircleDiameter)
                for (var i = 0; i < properties.ToothCount; i++)
                {
                    var pointR = pointsListR[i][0];
                    var pointL = pointsListL[i][0];
                    var intersectionR = new Point();
                    Intersect(centre, properties.DedendumCircleDiameter / 20,
                        centre, pointR, ref intersectionR);
                    var intersectionL = new Point();
                    Intersect(centre, properties.DedendumCircleDiameter / 20,
                        centre, pointL, ref intersectionL);
                    sketch.Figures.AddCircularArcByCenterStartEnd(centre.X, centre.Y, intersectionL.X, intersectionL.Y,
                        intersectionR.X, intersectionR.Y);
                }
            else
                for (var i = 0; i < properties.ToothCount; i++)
                {
                    var pointR = pointsListR[i][0];
                    var pointL = pointsListL[i][0];
                    var intersectionR = new Point();
                    sketch.Figures.AddCircularArcByCenterStartEnd(centre.X, centre.Y, pointL.X, pointL.Y,
                        pointR.X, pointR.Y);
                }
        }


        /// <summary>
        /// Adds the Addendums arc to the sketch
        /// </summary>
        /// <param name="sketch"></param>
        private void DrawAddedendumArcs(IADSketch sketch)
        {
            var centre = new Point(properties.WheelCentreX, properties.WheelCentreY);
            for (var i = 0; i < properties.ToothCount; i++)
            {
                int j;
                var lpR = pointsListR[i];
                if (i == properties.ToothCount - 1)
                    j = 0;
                else
                    j = i + 1;

                var lpL = pointsListL[j];
                var pR = lpR[lpR.Count - 1];
                var pL = lpL[lpL.Count - 1];
                sketch.Figures.AddCircularArcByCenterStartEnd(centre.X, centre.Y, pR.X, pR.Y,
                    pL.X, pL.Y);
            }
        }


        /// <summary>
        /// Draws lines from ends of the dedendum arc to the ends of the involute curves.
        /// </summary>
        /// <param name="sketch"></param>
        private void DrawDedendumToBaseCircleLines(IADSketch sketch)
        {
            var centre = new Point(properties.WheelCentreX, properties.WheelCentreY);


            foreach (var pointlist in pointsListR)
            {
                var endPoint = pointlist[0];
                var intersectionR = new Point();
                Intersect(centre, properties.DedendumCircleDiameter / 20,
                    centre, endPoint, ref intersectionR);
                sketch.Figures.AddLine(intersectionR.X, intersectionR.Y, endPoint.X, endPoint.Y);
            }

            foreach (var pointlist in pointsListL)
            {
                var endPoint = pointlist[0];
                var intersectionL = new Point();
                Intersect(centre, properties.DedendumCircleDiameter / 20,
                    centre, endPoint, ref intersectionL);
                sketch.Figures.AddLine(intersectionL.X, intersectionL.Y, endPoint.X, endPoint.Y);
            }
        }

        /// <summary>
        /// Just draws reference circles
        /// </summary>
        /// <param name="sketch"></param>
        private void DrawReferenceCircles(IADSketch sketch)
        {
            // draw base circle reference figure
            var baseCircle = sketch.Figures.AddCircle(0, 0, Properties.BaseCircleDiameter / 2 / 10);
            baseCircle.IsReference = true;

            // draw dedendum circle reference figure
            var dedendumCircle = sketch.Figures.AddCircle(0, 0, Properties.DedendumCircleDiameter / 2 / 10);
            dedendumCircle.IsReference = true;

            // draw pitch circle reference figure
            var pitchCircle = sketch.Figures.AddCircle(0, 0, Properties.PitchCircleDiameter / 2 / 10);
            pitchCircle.IsReference = true;

            // draw addendum circle reference figure
            var addendumCircle = sketch.Figures.AddCircle(0, 0, Properties.AddendumCircleDiameter / 2 / 10);
            addendumCircle.IsReference = true;
        }

        /// <summary>
        /// Calls methods that generate lists of points representing th basic involute curves.
        /// Iterates through the teeth generating List<List<Point>> objects that hold the involute curves translated by the tooth angle.
        /// Adds the involute curves to the sketch.
        /// </summary>
        /// <param name="sketch"></param>
        private void DrawInvoluteCurves(IADSketch sketch)
        {
            var pointsR = InvoluteR();
            var pointsL = InvoluteL();


            for (var toothNum = 0; toothNum < properties.ToothCount; toothNum++)
            {
                var theta = 360 / (double) properties.ToothCount * toothNum * Math.PI / 180.0;
                var translatedRPoints = new List<Point>();
                foreach (var pointr in pointsR) translatedRPoints.Add(translatePoint(pointr, theta));

                var translatedLPoints = new List<Point>();
                foreach (var pointl in pointsL) translatedLPoints.Add(translatePoint(pointl, theta));

                pointsListR.Add(translatedRPoints);
                pointsListL.Add(translatedLPoints);
            }

            foreach (var listPoint in pointsListR) AddBsplineByInterpolation(sketch, listPoint);

            foreach (var listPoint in pointsListL) AddBsplineByInterpolation(sketch, listPoint);
        }


        /// <summary>
        /// Converts the List<Point> points to a format that can be used by the AlibreX method AddBsplineByInterpolation and adds the curve to the sketch. 
        /// </summary>
        /// <param name="sketch"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        private IADSketchBspline AddBsplineByInterpolation(IADSketch sketch, List<Point> points)
        {
            Array interpolationPoints = new double[points.Count * 2];
            var j = 0;
            foreach (var point in points)
            {
                interpolationPoints.SetValue(point.X, j++);
                interpolationPoints.SetValue(point.Y, j++);
            }

            return sketch.Figures.AddBsplineByInterpolation(ref interpolationPoints);
        }


        /// <summary>
        /// Creates a sketch on the specified plane
        /// </summary>
        /// <returns></returns>
        private IADSketch createSketch()
        {
            var sketch = Properties.Session.Sketches.AddSketch(null, Properties.Plane, "Involute Gear");
            return sketch;
        }


        /// <summary>
        /// Calculates the involute curve.
        /// </summary>
        /// <returns></returns>
        private List<Point> InvoluteR()
        {
            var centre = new Point(properties.WheelCentreX, properties.WheelCentreY);
            var baseRadius = properties.BaseCircleDiameter / 2;
            var points = new List<Point>();
            var stepSize = 90 / (double) properties.CountInvolutePoints * Math.PI / 180.0;
            var step = 0.0;
            // create the involute points
            Point priorPoint = null;
            for (var i = 0; i < properties.CountInvolutePoints; ++i)
            {
                var point = new Point()
                {
                    X = baseRadius / 10 * (Math.Cos(step) + step * Math.Sin(step)),
                    Y = baseRadius / 10 * (Math.Sin(step) - step * Math.Cos(step))
                };
                if (properties.DedendumCircleDiameter >= properties.BaseCircleDiameter)
                    if (priorPoint != null &&
                        IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, priorPoint) &&
                        !IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, point) &&
                        IsIntersecting(centre, properties.DedendumCircleDiameter / 20, priorPoint, point))
                    {
                        var Intersection = new Point();
                        var result = Intersect(centre, properties.DedendumCircleDiameter / 20,
                            priorPoint, point, ref Intersection);
                        if (result == 0) points.Add(Intersection);
                    }

                if (!IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, point) &&
                    IsInsideCircle(centre, properties.AddendumCircleDiameter / 20, point)) points.Add(point);

                if (priorPoint != null &&
                    IsIntersecting(centre, properties.AddendumCircleDiameter / 20, priorPoint, point))
                {
                    var Intersection = new Point();
                    var result = Intersect(centre, properties.AddendumCircleDiameter / 20,
                        priorPoint, point, ref Intersection);
                    if (result == 0) points.Add(Intersection);
                }

                priorPoint = point;
                step += stepSize;
            }

            return points;
        }


        /// <summary>
        /// Calculates the involute curve.
        /// </summary>
        /// <returns></returns>
        private List<Point> InvoluteL()
        {
            var centre = new Point(properties.WheelCentreX, properties.WheelCentreY);
            var baseRadius = properties.BaseCircleDiameter / 2;
            var points = new List<Point>();
            var stepSize = 90 / (double) properties.CountInvolutePoints * Math.PI / 180.0;
            var step = 0.0;
            var beta = properties.Beta * 2 * Math.PI / 180.0;
            // create the involute points
            Point priorPoint = null;
            for (var i = 0; i < properties.CountInvolutePoints; ++i)
            {
                var point = new Point()
                {
                    X = baseRadius / 10 * (Math.Cos(-step - beta) - step * Math.Sin(-step - beta)),
                    Y = baseRadius / 10 * (Math.Sin(-step - beta) + step * Math.Cos(-step - beta))
                };
                if (properties.DedendumCircleDiameter >= properties.BaseCircleDiameter)
                    if (priorPoint != null &&
                        IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, priorPoint) &&
                        !IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, point) &&
                        IsIntersecting(centre, properties.DedendumCircleDiameter / 20, priorPoint, point))
                    {
                        var Intersection = new Point();
                        var result = Intersect(centre, properties.DedendumCircleDiameter / 20,
                            priorPoint, point, ref Intersection);
                        if (result == 0) points.Add(Intersection);
                    }

                if (!IsInsideCircle(centre, properties.DedendumCircleDiameter / 20, point) &&
                    IsInsideCircle(centre, properties.AddendumCircleDiameter / 20, point)) points.Add(point);

                if (priorPoint != null &&
                    IsIntersecting(centre, properties.AddendumCircleDiameter / 20, priorPoint, point))
                {
                    var Intersection = new Point();
                    var result = Intersect(centre, properties.AddendumCircleDiameter / 20,
                        priorPoint, point, ref Intersection);
                    if (result == 0) points.Add(Intersection);
                }

                priorPoint = point;
                step += stepSize;
            }

            return points;
        }


        /// <summary>
        /// Translates a point about an angle
        /// </summary>
        /// <param name="point"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        private Point translatePoint(Point point, double theta)
        {
            var result = new Point()
            {
                X = Math.Cos(theta) * point.X - Math.Sin(theta) * point.Y,
                Y = Math.Sin(theta) * point.X + Math.Cos(theta) * point.Y
            };
            return result;
        }


        /// <summary>
        /// Method to calculate if a specified checkPoint is within a circle 
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="checkPoint"></param>
        /// <returns>Return bool true if the checkPoint is within the specifies circle. Otherwise false</returns>
        private bool IsInsideCircle(Point CirclePos, double CircleRad, Point checkPoint)
        {
            if (Math.Sqrt(Math.Pow(CirclePos.X - checkPoint.X, 2) +
                          Math.Pow(CirclePos.Y - checkPoint.Y, 2)) < CircleRad)
                return true;
            else return false;
        }

        /// <summary>
        /// Method to calculate if a line between two points intersects a given circle
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="LineStart"></param>
        /// <param name="LineEnd"></param>
        /// <returns></returns>
        private bool IsIntersecting(Point CirclePos, double CircleRad, Point LineStart,
            Point LineEnd)
        {
            if (IsInsideCircle(CirclePos, CircleRad, LineStart) ^
                IsInsideCircle(CirclePos, CircleRad, LineEnd))
                return true;
            else return false;
        }

        /// <summary>
        // Method to calculate the absolute position where a line intersects a circle.
        // The position is available in the ref Point Intersection.
        // Method will return -1 if:
        // 1 The line is tangential to the circle
        // 2 One or both points are exactly ON the circle
        // 3 The line intersects at two points
        //
        //This function takes the intersection point as a ref parameter and returns either -1 (no intersection) or 0 (intersection found). I used an int return value in case you want to extend this to differentiate the edge cases. The intersection is calculated from elementary geometry - remember that a line is expressed as (see : Slope Intercept and Point Slope Form )
        //
        // y = M*x + B
        //     and a circle (centered at (C.x, C.y) with radius r) is
        //
        // (x - C.x)^2 + (y - C.y)^2 - r^2 = 0
        // You solve this system of equations by substitution :
        //
        // (x - C.x)^2 + ((M*x + B) - C.y)^2 - r^2 = 0
        // Expanding and collecting terms you get :
        //
        // (1+M^2)x^2 + 2*(MB - MC.y - C.x)x + (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y) = 0
        // This is a standard quadratic equation of the form
        //
        //     ax^2 + bx + c = 0
        // where :
        // a = (1+M^2)
        // b = 2*(MB - MC.y - C.x)
        // c = (C.x^2 + C.y^2 + B^2 - r^2 - 2B*C.y)
        // Which can be solved by the quadratic formula (see : Quadratic Formula ):
        //
        // x = (-b ± Sqrt(b^2 - 4ac))/(2a)
        // This gives two roots for the infinite line on which our line segment lies - we do a final check above to make sure that we choose the solution for our specific line segment.
        ///
        /// 
        /// </summary>
        /// <param name="CirclePos"></param>
        /// <param name="CircleRad"></param>
        /// <param name="LineStart"></param>
        /// <param name="LineEnd"></param>
        /// <param name="Intersection"></param>
        /// <returns>Returns 0 if a solution is found otherwise returns -1</returns>
        private int Intersect(Point CirclePos, double CircleRad,
            Point LineStart, Point LineEnd, ref Point Intersection)
        {
            if (IsIntersecting(CirclePos, CircleRad, LineStart, LineEnd))
            {
                //Calculate terms of the linear and quadratic equations
                var m = (LineEnd.Y - LineStart.Y) / (LineEnd.X - LineStart.X);
                var d = LineStart.Y - m * LineStart.X;
                var a = 1 + m * m;
                var b = 2 * (m * d - m * CirclePos.Y - CirclePos.X);
                var c = CirclePos.X * CirclePos.X + d * d + CirclePos.Y * CirclePos.Y -
                        CircleRad * CircleRad - 2 * d * CirclePos.Y;
                // solve quadratic equation
                var sqRtTerm = Math.Sqrt(b * b - 4 * a * c);
                var x = (-b + sqRtTerm) / (2 * a);
                // make sure we have the correct root for our line segment
                if (x < Math.Min(LineStart.X, LineEnd.X) ||
                    x > Math.Max(LineStart.X, LineEnd.X))
                    x = (-b - sqRtTerm) / (2 * a);

                //solve for the y-component
                var y = m * x + d;
                // Intersection Calculated
                Intersection = new Point(x, y);
                return 0;
            }

            // Line segment does not intersect at one point.  It is either 
            // fully outside, fully inside, intersects at two points, is 
            // tangential to, or one or more points is exactly on the 
            // circle radius.
            Intersection = new Point(0, 0);
            return -1;
        }
    }
}