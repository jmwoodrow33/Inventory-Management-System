//using ITMS.Plugins.InMemory;
using ITMS.UseCases.Inventories;
using ITMS.UseCases.Inventories.Interfaces;
using ITMS.UseCases.PluginInterfaces;
using ITMS.WebApp.Components;
using Microsoft.EntityFrameworkCore;
using ITMS.Plugins.EFCoreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<ITMSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagement"));
});

builder.Services.AddRazorComponents();

builder.Services.AddSingleton<IInventoryRepository, InventoryEFCoreRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();

builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();

builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();

builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();

//builder.Services.AddDbContext<ITMSContext>(options =>
//{
//    options.UseSqlServer = true;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
