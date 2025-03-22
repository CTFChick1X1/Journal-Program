using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\n📒 JOURNAL MENU:");
            Console.WriteLine("1️⃣ Write a new entry");
            Console.WriteLine("2️⃣ Display journal");
            Console.WriteLine("3️⃣ Save journal to CSV");
            Console.WriteLine("4️⃣ Load journal from CSV");
            Console.WriteLine("5️⃣ Exit");
            Console.Write("➡ Choose an option: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n💡 Prompt: {prompt}");
                    Console.Write("📝 Your response: ");
                    string response = Console.ReadLine() ?? string.Empty;
                    journal.AddEntry(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response));
                    Console.WriteLine("\n✅ Entry added successfully!\n");
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("\n💾 Enter filename to save (e.g., journal.csv): ");
                    string saveFilename = Console.ReadLine() is string input ? input.Trim() : string.Empty;
                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToCsv(saveFilename);
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid filename. Please try again.");
                    }
                    break;

                case "4":
                    Console.Write("\n📂 Enter filename to load (e.g., journal.csv): ");
                    string loadFilename = (Console.ReadLine() ?? string.Empty).Trim();
                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromCsv(loadFilename);
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid filename. Please try again.");
                    }
                    break;

                case "5":
                    Console.WriteLine("\n👋 Goodbye! Happy journaling!\n");
                    return;

                default:
                    Console.WriteLine("\n❌ Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
