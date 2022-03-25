Console.WriteLine("Naming Convention Utilities\n");

string? directory;
do
{
    Console.Write("Target folder: ");
    directory = Console.ReadLine();

    if (directory == null)
    {
        Console.WriteLine("Invalid input.\n");
    }
    else
    {
        Console.WriteLine("Processing files...\n");
    }
} 
while (directory is null);

foreach (string files in Directory.GetFiles(directory))
{
    Console.WriteLine(System.IO.Path.GetFileName(files));
}

Console.WriteLine("\nDone.");