If you want to open this open source software in visual studio / any other editor, you first have to obtain Bunifu_UI_v1.5.3.dll!

This dll is required for the user interface. Without it you won't be able to run the solution.
I have not included this dll on github, because the dll is not free (see: https://devtools.bunifu.co.ke/)

How you obtain this dll is up to you. In order to get this solution working you need to:
1. Add it to the main class library "RemindMe"  (Right-click the library, Add->Existing item)
2. Set build action to Embedded Resource
3. Change the string in program.cs in static void Main(string[] args) if your dll is not named "Bunifu_UI_v1.5.3.dll"
