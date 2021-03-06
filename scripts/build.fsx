// include Fake lib
#r @"..\packages\FAKE\tools\FakeLib.dll"
#r @"..\packages\Steinpilz.DevFlow.Fake\tools\Steinpilz.DevFlow.Fake.Lib.dll"

open Fake
open Steinpilz.DevFlow.Fake 

let libParams = Lib.setup <| fun p -> 
    { p with 
        PublishProjects = !!"src/app/**/*.csproj"
        UseDotNetCliToPack = true
        NuGetFeed = 
            { p.NuGetFeed with 
                ApiKey = environVarOrFail <| "KRAFTEQ_NUGET_API_KEY" |> Some
            }
    }

RunTargetOrDefault "Watch"