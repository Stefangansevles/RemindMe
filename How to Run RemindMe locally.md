# Cloning RemindMe

## Important note: You have to obtain Bunifu_UI_v1.5.3.dll yourself. I can not supply this for you.

### This file describes how you can clone this repository and run it locally in Visual Studio

1. Clone the respository e.g. `git clone https://github.com/Stefangansevles/RemindMe`

2. Open the .sln file

![](https://i.imgur.com/tRUBF8g.png)

![](https://i.imgur.com/Cw7V3YO.png)

3. Add references to the DLL's from `RemindMe/External_DLL`. Select all and press `OK`, See screenshot:

![](https://i.imgur.com/hV3qgIp.png) ![](https://i.imgur.com/BOCiWiw.png) ![](https://i.imgur.com/xNrUBQI.png)

Make sure none of the references still has an exclamation mark ( ![](https://i.imgur.com/4RsTCZp.png) ), if they do, add the reference again 

If you have obtained the bunifu dll, and visual studio is still giving you an error after you added the reference, delete the file-reference in /external_dll like so: 

![](https://i.imgur.com/5RogAEi.png)

Then, add it again

![](https://i.imgur.com/U5TtHXB.png)

### Important: Click on the added dll and set it's `Build Action` to `Embedded Resource`

![](https://i.imgur.com/K6wXtKs.png)

Now run RemindMe :)

If for some reason you are getting a lot of errors saying visual studio doesn't recognize things like `Reminder`, `Database.Entity`, `Songs`, etc, then use `Run custom tool` on `RemindMeDb.Context.tt` like so:

![](https://i.imgur.com/qYtNQZX.png)

This should generate them.


lastly, visit https://github.com/Stefangansevles/RemindMe/issues if something doesn't work.
