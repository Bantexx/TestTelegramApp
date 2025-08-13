using Microsoft.JSInterop;

namespace TestTelegramApp.Services;

public class TelegramService(IJSRuntime jsRuntime)
{
    public async Task InitAsync() => 
        await jsRuntime.InvokeVoidAsync("Telegram.WebApp.ready");

    public async Task<string> GetUserDataAsync() => 
        await jsRuntime.InvokeAsync<string>("eval", "JSON.stringify(Telegram.WebApp.initDataUnsafe.user)");

    public async Task CloseAppAsync() => 
        await jsRuntime.InvokeVoidAsync("Telegram.WebApp.close");
}