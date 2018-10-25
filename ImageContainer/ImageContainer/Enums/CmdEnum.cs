namespace ImageContainer.Enums
{
    internal enum CmdEnum
    {
        SW_HIDE = 0, //Hides the window and activates another window.
        SW_MAXIMIZE = 3, //Maximizes the specified window.
        SW_MINIMIZE = 6, //Minimizes the specified window and activates the next top-level window in the z-order.
        SW_RESTORE = 9, //Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
        SW_SHOW = 5, //Activates the window and displays it in its current size and position.
        SW_SHOWMAXIMIZED = 3, //Activates the window and displays it as a maximized window.
        SW_SHOWMINIMIZED = 2, //Activates the window and displays it as a minimized window.
        SW_SHOWMINNOACTIVE = 7, //Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
        SW_SHOWNA = 8, //Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.
        SW_SHOWNOACTIVATE = 4, //Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not activated.
        SW_SHOWNORMAL = 1 //Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
    }
}
