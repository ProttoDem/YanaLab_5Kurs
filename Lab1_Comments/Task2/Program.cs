using Task2;

var x = 12.47;  // Initialize a double variable x
var z = 0.18;   // Initialize a double variable z

// Arrays ai and bi contain numeric data for further calculations
double[] ai = [0.2, 0.4, 2.2, 1, 2, 3.4, -2.4, -4.1, 1.1, -5.1]; 
double[] bi = [1.5, -4.4, 5, 4.1, 2, 0, 0.5, 7.1, 7.4, 1.1];

var tasksResolver = new TasksResolver();  // Create an instance of TasksResolver

// Call Task1 and print the result
Console.WriteLine($"Result of task1: {tasksResolver.Task1(x, z, ai, bi)}");
Console.WriteLine("--------------------------------------------------------");

Console.WriteLine("Result of task2:");

// Create an instance of VektorPrinter for integers and print an integer array
var vektorPrinterInteger = new VektorPrinter<int>();  
int[] intArray = [1, 2, -5, 100];  
vektorPrinterInteger.PrintVektor(intArray);

// Create an instance of VektorPrinter for chars and print a character array
var vektorPrinterChar = new VektorPrinter<char>();  
char[] charArray = ['1', 'a', '@', ' ', '_'];  
vektorPrinterChar.PrintVektor(charArray);

Console.WriteLine("--------------------------------------------------------");

// Call Task3 and print the result
Console.WriteLine($"Results of task3: {tasksResolver.Task3()}");
Console.WriteLine("--------------------------------------------------------");