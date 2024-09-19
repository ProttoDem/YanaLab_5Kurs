namespace Task2;

public class VektorPrinter<T>
{
    // PrintVektor: Prints the contents of an array
    public void PrintVektor(T[] ai)
    {
        Console.Write("Array contains: [");
        for (int i = 0; i < ai.Length; i++)  // Iterate over the array
        {
            Console.Write(ai[i] != null ? ai[i] : "null");  // Print each element, handling nulls
            if (i != ai.Length - 1)  // Add a comma between elements, except after the last one
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");  // End the array printout
    }
}