namespace Task2;

public class TasksResolver
{
    // Task1: Performs calculations based on inputs x, z, ai, and bi
    public double Task1(double x, double z, double[] ai, double[] bi)
    {
        // Complex mathematical formula that calculates value 'p' 
        var p = (Math.Pow(Math.Abs(0.3 - x * z), 1 / 7) / SumRoot(1, 5, 3, ai, bi)) 
              - (SumRoot(6, 10, 2, ai, bi)/(Math.Pow(Math.Abs(23.1 - Math.Sin(x)), 1/9))) 
              + (Math.Pow(Math.Abs(0.92 - z), 1/2) / SumRoot(2, 7, 7, ai, bi));
        
        return p;  // Return the result of the calculation
    }

    // SumRoot: Calculates the sum of ai[i] + bi[i], raised to the 1/rootValue power for a given range
    private double SumRoot(int startIndex, int finishIndex, int rootValue, double[] ai, double[] bi)
    {
        var sum = 0D;  // Initialize sum to zero
        
        // Loop over the range of indexes and accumulate the sum of roots
        for (int i = startIndex - 1; i < finishIndex; i++)
        {
            sum += Math.Pow(ai[i] + bi[i], 1 / rootValue);
        }

        return sum;  // Return the calculated sum
    }
    
    // Task3: Solves two quadratic equations and calculates value u
    public double Task3()
    {
        double[] xRoots = SolveSquareEquations(3, -6, 1);  // Solve quadratic equation for x1 and x2
        double x1 = xRoots[0];  // Get the smaller root
        double x2 = xRoots[1];  // Get the larger root
        
        double[] yRoots = SolveSquareEquations(2, -1, 4);  // Solve quadratic equation for y1 and y2
        double y1 = yRoots[0];  // Get the smaller root
        double y2 = yRoots[1];  // Get the larger root
        
        // If roots are NaN (complex), set them to 0
        if (double.IsNaN(x1) || double.IsNaN(x2))
        {
            x1 = 0;
            x2 = 0;
        }
        if (double.IsNaN(y1) || double.IsNaN(y2))
        {
            y1 = 0;
            y2 = 0;
        }
        
        double t = 2.0;  // Set the base t value
        
        // Calculate u based on the formula
        double u = Math.Pow(t, x1 + y1) - Math.Exp(x2 - y2);

        return u;  // Return the result of the calculation
    }

    // SolveSquareEquations: Solves a quadratic equation ax^2 + bx + c = 0
    static double[] SolveSquareEquations(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;  // Calculate the discriminant
        if (discriminant < 0D)  // If discriminant is negative, return NaN (complex roots)
        {
            return new double[] { double.NaN, double.NaN };
        }

        // Calculate the roots using the quadratic formula
        double sqrtDisc = Math.Sqrt(discriminant);
        double x1 = (-b + sqrtDisc) / (2 * a);  // First root
        double x2 = (-b - sqrtDisc) / (2 * a);  // Second root
        return new double[] { Math.Min(x1, x2), Math.Max(x1, x2) };  // Return the roots in ascending order
    }
}