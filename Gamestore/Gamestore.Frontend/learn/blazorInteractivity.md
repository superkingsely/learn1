Program.cs → enables interactivity
App.razor → applies it to routes
Component → optional override
############################

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

####################################
1. Why your page was not working

Your input binding didn’t work because the app was running in Static Server Rendering.

Meaning:

HTML renders ✔

C# executes once ✔

No interactivity ❌

No events

No @bind

No @onclick
################################
Per component override

You can override:

@rendermode InteractiveWebAssembly
@rendermode InteractiveServer
@rendermode InteractiveAuto
############################################