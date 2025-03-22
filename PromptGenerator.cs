using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?",
        "What am I grateful for today?",
        "How did I step outside of my comfort zone today?",
        "If I could give my future self advice, what would it be?",
        "What is one goal I want to achieve tomorrow?"
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_rand.Next(_prompts.Count)];
    }
}
