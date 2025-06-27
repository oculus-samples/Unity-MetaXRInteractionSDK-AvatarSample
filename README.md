![Avatar Samples Banner](./Media/AvatarsHumanSkinDefault.gif "Avatar Integration Samples")

# Avatar Integration Samples

The Avatar Integration sample project contains sample scenes demonstrating the integration of Meta's [Avatars SDK](https://developer.oculus.com/documentation/unity/meta-avatars-overview/) with the [Meta XR Interaction SDK](https://developer.oculus.com/documentation/unity/unity-isdk-interaction-sdk-overview/). These samples provide practical examples of creating custom hand poses and object interactions. The integration is handled by two new prefabs, **OculusInteractionAvatarSdkManager** and **Avatar**. You can find them in the **Assets/Prefabs** folder in Unity once you complete the **Getting started** section.


## Licenses
The **Oculus Integration** package is released under the [Oculus SDK License Agreement](https://developer.oculus.com/licenses/oculussdk).
The MIT licence applies to the files and assets in the **Assets/** folder.
Otherwise, if an individual file does not indicate which license it is subject to, then the Oculus License applies.

## Getting started

1. Clone this repo using either the green "Code" button above or this command in the terminal.
    ```sh
    git clone https://github.com/oculus-samples/Unity-MetaXRInteractionSDK-AvatarSample.git
    ```

    The repo is cloned to your computer. This may take a couple minutes depending on your internet speed.

1. In Unity Hub, click **Add** > **Add Project from Disk** and select the **Unity-MetaXRInteractionSDK-AvatarSample** folder on your machine.

1. Open the project in Unity version 2022.3.11f1 or newer, then load the [Assets/Scenes/AvatarGrabExamples](Assets/Scenes/AvatarGrabExamples.unity) or [Assets/Scenes/AvatarPokeExamples](Assets/Scenes/AvatarPokeExamples.unity) scenes.

## Interactions

The project contains two sample scenes that showcase different interactions implemented with the Interaction SDK and integrated with Avatars.
* AvatarGrabExamples - Demonstrates "Hand Grab" interactions with Avatars.
* AvatarPokeExamples - Demonstrates "Poke" interactions with Avatars.

For information about the individual SDKs, see the [Interaction SDK documentation](https://developer.oculus.com/documentation/unity/unity-isdk-interaction-sdk-overview/) and the [Avatars SDK documentation](https://developer.oculus.com/documentation/unity/meta-avatars-overview/).
