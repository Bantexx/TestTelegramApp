using Microsoft.AspNetCore.Components;
using TestTelegramApp.Models;

namespace TestTelegramApp.Pages;

public partial class Start : ComponentBase
{
    private decimal Balance = 1000;
    private int TechLevel = 1;
    private int Clients = 10;
    private System.Threading.Timer _incomeTimer;
    private bool showIncomeNotification;
    private decimal lastIncome;
    
    private List<Upgrade> Upgrades = new()
    {
        new Upgrade("Облачный сервер", 500, 1.2m),
        new Upgrade("AI Аналитика", 1200, 2.5m),
        new Upgrade("Блокчейн интеграция", 3000, 5.0m),
        new Upgrade("Квантовые вычисления", 7500, 8.0m)
    };

    protected override async Task OnInitializedAsync()
    {
        await TelegramService.InitAsync();
        _incomeTimer = new Timer(GenerateIncome, null, 1000, 5000);
    }

    private void DevelopFeature()
    {
        Balance += 50 * TechLevel;
    }

    private async void BuyUpgrade(Upgrade upgrade)
    {
        if (Balance >= upgrade.Cost)
        {
            Balance -= upgrade.Cost;
            TechLevel = (int)(TechLevel * upgrade.Multiplier);
            upgrade.Cost *= 2;
            upgrade.Level++;
            Clients += new Random().Next(5, 20);
            StateHasChanged();
        }
    }

    private async void GenerateIncome(object state)
    {
        lastIncome = Clients * TechLevel * 0.1m;
        Balance += lastIncome;
        
        showIncomeNotification = true;
        StateHasChanged();
        
        await Task.Delay(1800);
        showIncomeNotification = false;
        StateHasChanged();
    }

    public void Dispose()
    {
        _incomeTimer?.Dispose();
        GC.SuppressFinalize(this);
    }

    
}