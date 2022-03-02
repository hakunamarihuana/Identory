![Identory](https://socialify.git.ci/hakunamarihuana/Identory/image?description=1&descriptionEditable=%0A&font=Source%20Code%20Pro&language=1&logo=https%3A%2F%2Fwww.upload.ee%2Fimage%2F13929962%2Fphoto_2022-01-20_14-46-20.jpg&name=1&owner=1&pattern=Circuit%20Board&stargazers=1&theme=Light)


<!-- ABOUT THE PROJECT -->
## About The Project
.NET wrapper written for automating the [Identory Anti-Detect](https://identory.com/en/) browser.

### Built With
* [.NET/C# 8](https://github.com/dotnet)

<!-- GETTING STARTED -->
## Getting Started
This library is quite small and has been built with simplicity in mind. <br/>
By following the [official documentation](https://docs.identory.com/) figuring things out should be rather easy.<br/>
If you happen to run into any problems or find something confusing, feel free to open up an [issue](https://github.com/hakunamarihuana/Identory/issues) on GitHub.

#### Simple example that shows creating and starting a profile using the wrapper. 
```csharp
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

```

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.
