namespace MegaDesk_2._0_TeamCumorah
{
    class Desk
    {
        #region Get and Set Variables
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawer { get; set; }
        public DesktopMaterial desktopMaterial { get; set; }
        #endregion

        #region Declare Constant Values
        //Desk Constraints
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;
        public const int MINDRAWER = 0;
        public const int MAXDRAWER = 7;
        #endregion

        #region Create enum DesktopMaterial
        public enum DesktopMaterial
        {
            Oak = 200,
            Laminate = 100,
            Pine = 50,
            Rosewood = 300,
            Veneer = 125
        }
        #endregion
    }
}
