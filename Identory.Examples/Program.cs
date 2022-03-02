
using Identory;

var identory = await Identory.Identory.StartIdentory("7d1a45df6dddf3b23c9d000494ffd1a8aee86eda");

var identoryProfile = new Identory.Models.Profile.DesktopProfile("test");
identoryProfile.Platform = Identory.Models.Enum.Platform.Win32;
identoryProfile.OnStartUp = Identory.Models.Enum.StartupAction.DoNothing;

identory.Profile.UpsertProfile(identoryProfile).Result.Match(profile =>
{
    global::System.Console.WriteLine(profile.ProfileId);
        identory.Profile.StartProfile(profile.ProfileId).Result.Match(
        session =>
        { 
            global::System.Console.WriteLine(session.BrowserWSEndpoint); 
        },
        fail =>
        { 
            global::System.Console.WriteLine(fail.Message);
        });
},
error =>
{
    global::System.Console.WriteLine(error.Message);
});


