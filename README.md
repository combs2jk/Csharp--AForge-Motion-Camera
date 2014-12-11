Csharp--AForge-Motion-Camera
============================

Customizable program captures movement on connected camera, saves it to hard drive.

This is my first post to GitHub; still not entirely familiar with the site. Have mercy.

This is a project I did a few months back on C#, it captures frames from the connected camera using AForge and then uses filters to detect motion above a certain size and throws it to a background process that compares the captured frames to a control frame which finally saves the frames that are the most different compared to the control frame (with the time and date) to the hard-drive.

The idea of the whole thing was to have a camera that only records important stuff (motion).

Uses AForge framework for capturing the frames, and various AForge filters to detect the motion.
