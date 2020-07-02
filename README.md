# Rise of Pharaohs

![Event](https://github.com/chamikaCN/Rise_of_Pharaohs-CSEnightApp/blob/master/ReadME%20contents/event.jpg)
*Photograph of the event held on **12th November 2019***

## Introduction
This is an augmented reality application created using __*unity3D*__ and __*vuforia AR*__ package for the **Rise of Pharaohs(2019)** the official welcome event of 18 batch of the Computer science and Engineering Department, University of Moratuwa. This Application is the last step of a treasure hunt game which was conducted to invite student to the event in an innovative attractive way while providing an oppurtunity to enjoy and learn about the department and the university. For the entertainment and organization of games at the event, Whole batch was divided into 4 groups. The groups(factions) were named based on the Egyptian Gods to befit the theme of the event.
* Horus
* Bastet
* Osiris
* Anubis

You can download the .apk file from [here](https://drive.google.com/open?id=1x6vIHdCqeNkI_oby44oaPJRjyf7gmdgu)

## Procedure
The first part of the Tresure Hunt is conducted through a seperate flutter based application [CSE night app](https://github.com/kdsuneraavinash/cse-night-app) which was given to students via a physical invitation without any specific details. Upon completing the 5 tasks (including puzzles and activities) specified in that application students have to wait until 25% percent of the total complete those. Then the link to download this application is revealed there with a passcode specific to each student.
After downloading this app students are asked to input the passcode they obtained previously. This code includes information about the faction they belong and the index number which is used to fetch the name of the student. Those information is used to validate the accuracy of passcode.

### Login Scene
If the app is opened for the first time this screen will show only the passcode input. Otherwise the name and the index number of the last logged student as well as the invitation and faction details will be shown here. After entering a valid passcode you can enter the game. Few passcodes are listed below for testing purposes under each faction. 
1. House Horus - 003614005080473
1. House Bastet - 851027547040182
1. House Osiris - 942008365070397
1. House Anubis - 148559071080406

### Activity Scene

<p align="center">
    <img src="https://github.com/chamikaCN/Rise_of_Pharaohs-CSEnightApp/blob/master/ReadME%20contents/ImageTarget.jpg" alt="Image Target]" height="800px">
  </br><i>Image Target</i>
 </p>

This screen requiers you to indicate the image target to the camera. After detecting the target app renders a scene with desert themed assets. There are 8 artifacts of pharaoh sculptures hidden among them. You have to find and tap on each to revel the name of the event **Rise of Paharaohs** and to proceed to next screen.
Most assets used here are imported from [this unity package](https://assetstore.unity.com/packages/3d/environments/landscapes/desert-kits-64-sample-86482) in asset store.

<p align="center">
    <img src="https://github.com/chamikaCN/Rise_of_Pharaohs-CSEnightApp/blob/master/ReadME%20contents/Screenshot_20200517-135257.png" alt="Activity scene" height="800px">
</br><i>Screenshot of the scene</i>
</p>



### Faction Scene

After detecting the image target you will be shown to which faction you belong with a statue of the god representing faction.
All 4 untextured models can be found on [Free3d.com](https://free3d.com/user/printable_models) which were textured specifically for this project using Blender.

<p align="center">
    <img src="https://github.com/chamikaCN/Rise_of_Pharaohs-CSEnightApp/blob/master/ReadME%20contents/Screenshot_20200517-140109.png" alt="Faction scene" height="800px">
</br><i>Screenshot of the scene</i>
</p>



### Info Scene
This scene reveals the date, the venue and the time of the event and invite the student to ***COME, SEE AND ENJOY***.

All the audio files were extracted from [this video](https://www.youtube.com/watch?v=QD6Ow5rF-GY&t=116s)
