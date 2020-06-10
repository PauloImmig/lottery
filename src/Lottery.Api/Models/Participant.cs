using System;
using System.Collections.Generic;
using System.Linq;

public class Participant
{
    public Guid Id { get; set; }
    public Guid LotteryId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public LuckNumbers LuckNumbers { get; set; } = new LuckNumbers();
    public Participant()
    {
        
    }
    public Participant(Guid id, Guid lotteryId, string name, string email)
    {
        Id = id;
        LotteryId = lotteryId;
        Name = name;
        Email = email;
    }

    public void AddRandomNumbers(int quantity)
    {
        var rnd = new Random();
        LuckNumbers.AddRange(Enumerable.Repeat(0, quantity).Select(x => rnd.Next()));
    }
}