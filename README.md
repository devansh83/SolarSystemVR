# How to run
1. Pull from the 'FinalApp' branch.
2. Go to Unity Hub and click on Add Project and select the downloaded folder.
3. Enable USB Debugging on your Android phone from the developer options (steps differ from phone to phone to please refer to the internet for your particular model)


## Import the SDK and Create a New Project

Follow these steps to import the Unity SDK and create a new project:

1. Open Unity and create a new 3D project.
2. In Unity, go to `Window` > `Package Manager`.
3. Click `+` and select `Add package from git URL`.
4. Paste `https://github.com/googlevr/cardboard-xr-plugin.git` into the text entry field.
5. The package should be added to the installed packages.
6. Navigate to the Google Cardboard XR Plugin for Unity package. In the Samples section, choose `Import into Project`.
7. The sample assets should be loaded into `Assets/Samples/Google Cardboard/<version>/Hello Cardboard`.

## Configuring Android Project Settings

1. Navigate to `File` > `Build Settings`.
2. Select `Android` and choose `Switch Platform`.
3. Select `Add Open Scenes` and choose `HelloCardboard`.

### Player Settings

#### Resolution and Presentation

1. Navigate to `Project Settings` > `Player` > `Resolution and Presentation`.
2. Set the Default Orientation to `Landscape Left` or `Landscape Right`.
3. Disable Optimized Frame Pacing.

**Note:** While supported by the Cardboard XR plugin, the `Portrait` and `Portrait Upside Down` orientations may not provide enough room for eye rendering on devices.

#### Other Settings

1. Navigate to `Project Settings` > `Player` > `Other Settings`.
2. Choose `OpenGLES2`, `OpenGLES3`, or `Vulkan`, or any combination of them in Graphics APIs.
3. Select `Android 8.0 'Oreo' (API level 26)` or higher in Minimum API Level.
4. Select `API level 33` or higher in Target API Level.
5. Select `IL2CPP` in Scripting Backend.
6. Select desired architectures by choosing `ARMv7`, `ARM64`, or both in Target Architectures.
7. Select `Require` in Internet Access.
8. Specify your company domain under Package Name.

**If Vulkan was selected as Graphics API:**

- Uncheck `Apply display rotation during rendering` checkbox in Vulkan Settings.

**If the Unity version is 2021.2 or above:**

- Select `ETC2` in Texture compression format.

**If the Unity version is 2023.1 or later:**

- Select `Activity` and clear `GameActivity` in Application Entry Point.

### Publishing Settings

1. Navigate to `Project Settings` > `Player` > `Publishing Settings`.
2. In the `Build` section, select `Custom Main Gradle Template` and `Custom Gradle Properties Template`.
3. Add the following lines to the dependencies section of `Assets/Plugins/Android/mainTemplate.gradle`:

```groovy
implementation 'androidx.appcompat:appcompat:1.6.1'
implementation 'com.google.android.gms:play-services-vision:20.1.3'
implementation 'com.google.android.material:material:1.6.1'
implementation 'com.google.protobuf:protobuf-javalite:3.19.4'
```

4. Add the following lines to `Assets/Plugins/Android/gradleTemplate.properties`:

```groovy
  android.enableJetifier=true
  android.useAndroidX=true
```

### XR Plug-in Management Settings
Navigate to Project Settings > XR Plug-in Management.

1. Select Cardboard XR Plugin under Plug-in Providers.


## Build your project
Navigate to File > Build Settings.

1. Select Build, or choose a device and select Build and Run.
