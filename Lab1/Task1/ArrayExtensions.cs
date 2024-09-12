namespace Task1;

public static class ArrayExtensions
{
    public static T[] Shuffle<T>(this T[] sequence)
    {
        return sequence.Shuffle(new Random());
    }

    public static T[] Shuffle<T>(this T[] sequence, Random randomNumberGenerator)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException("sequence");
        }

        if (randomNumberGenerator == null)
        {
            throw new ArgumentNullException("randomNumberGenerator");
        }

        T swapTemp;
        T[] values = sequence;
        int currentlySelecting = values.Length;
        while (currentlySelecting > 1)
        {
            int selectedElement = randomNumberGenerator.Next(currentlySelecting);
            --currentlySelecting;
            if (currentlySelecting != selectedElement)
            {
                swapTemp = values[currentlySelecting];
                values[currentlySelecting] = values[selectedElement];
                values[selectedElement] = swapTemp;
            }
        }

        return values;
    }
}