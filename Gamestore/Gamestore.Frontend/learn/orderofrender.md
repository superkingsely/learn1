🏗 What Actually Happens Internally

When Blazor creates your component, it:

Creates the class instance

Runs field initializers (heading = "cool")

Injects services

Calls OnInitialized

Calls OnParametersSet

Renders UI

So field initializers happen very early.

##################################################################333

🔄 Order of Execution (Important)

When component first loads:

OnInitialized

OnParametersSet

Render

OnAfterRender

If parameter changes later:

OnParametersSet

Render

OnAfterRender

#########################################

🧠 Practical Rule For You
✅ Use OnInitialized when:

Data does NOT depend on parameters

Static page load

Dashboard initial load

✅ Use OnParametersSet when:

Data depends on:

Route parameter

Parent component parameter

Changing input