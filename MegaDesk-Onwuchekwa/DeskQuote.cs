using System;

namespace MegaDesk_Onwuchekwa
{    
    class DeskQuote
    {
        string customerName = string.Empty;
        DateTime quoteDate = DateTime.Now;
        int rushDays = 0;
        Desk desk = new Desk();

        #region Constants
        private const int BASE_DESK_PRICE = 200;
        private const int DESK_SURFACE_AREA_THRESHOLD = 1000;
        private const int PRICE_PER_DRAWER = 50;
        private const int PRICE_PER_AREA = 1;
        private const int RUSH_MAX_THRESHOLD = 2000;
        #endregion

        // DesQuote constructor
        public DeskQuote(string customer, int rush, DateTime date, int width, int depth, int drawer, Desk.DesktopMaterial material)
        {
            customerName = customer;
            rushDays = rush;
            quoteDate = date;
            desk.Depth = depth;
            desk.Width = width;
            desk.Drawer = drawer;
            desk.desktopMaterial = material;
        }

        /// <summary>
        /// Uses the width and depth to calculate the area of the desk
        /// </summary>
        /// <returns>the area of the desk</returns>
        public int calcArea()
        {
            return desk.Width * desk.Depth;            
        }

        /// <summary>
        /// Check if the area of the desk is more than 1000 inches
        /// </summary>
        /// <returns>The extra area if it is more than 1000 inches</returns>
        public int calcSizeOverage()
        {
            int areaOverage = 0;
            if(calcArea() > DESK_SURFACE_AREA_THRESHOLD)
            {
                try
                {
                    areaOverage = calcArea() - DESK_SURFACE_AREA_THRESHOLD;
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return areaOverage;
        }

        /// <summary>
        /// Multiple the extra area by 1
        /// </summary>
        /// <returns>Return the price for the extra area</returns>
        public int calcSizeCost()
        {
            return calcSizeOverage() * PRICE_PER_AREA;
        }

        /// <summary>
        /// Calculate the amount for each drawer selected
        /// </summary>
        /// <returns>The amount for each drawer selected</returns>
        public int calcDrawer()
        {
            return desk.Drawer * PRICE_PER_DRAWER;
        }

        /// <summary>
        /// Calculate the price for each material selected
        /// </summary>
        /// <returns>The amount for each material selected</returns>
        public int calcMaterial()
        {
            int costOfMaterial = 0;

            switch (desk.desktopMaterial.ToString())
            {
                case "Oak":
                    costOfMaterial = 200;
                    break;
                case "Laminate":
                    costOfMaterial = 100;
                    break;
                case "Pine":
                    costOfMaterial = 50;
                    break;
                case "Rosewood":
                    costOfMaterial = 300;
                    break;
                case "Veneer":
                    costOfMaterial = 125;
                    break;
            }
            return costOfMaterial;
        }

        /// <summary>
        /// Calculates the amount to be paid for shipping
        /// </summary>
        /// <returns>The amount to be paid for shipping</returns>
        public int calcShippingCost()
        {
            int costOfShipping = 0;

            switch (rushDays)
            {                
                case 3:
                    if (calcArea() < DESK_SURFACE_AREA_THRESHOLD)
                    {
                        costOfShipping = 60;
                    }
                    else if (calcArea() >= DESK_SURFACE_AREA_THRESHOLD && calcArea() <= RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 70;
                    }
                    else if (calcArea() > RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 80;
                    }
                    break;
                case 5:
                    if (calcArea() < DESK_SURFACE_AREA_THRESHOLD)
                    {
                        costOfShipping = 40;
                    }
                    else if (calcArea() >= DESK_SURFACE_AREA_THRESHOLD && calcArea() <= RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 50;
                    }
                    else if (calcArea() > RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 60;
                    }
                    break;
                case 7:
                    if (calcArea() < DESK_SURFACE_AREA_THRESHOLD)
                    {
                        costOfShipping = 30;
                    }
                    else if (calcArea() >= DESK_SURFACE_AREA_THRESHOLD && calcArea() <= RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 35;
                    }
                    else if (calcArea() > RUSH_MAX_THRESHOLD)
                    {
                        costOfShipping = 40;
                    }
                    break;
                
            }
            return costOfShipping;
        }

        /// <summary>
        /// Gets the sum of all the cost for the Desk
        /// </summary>
        /// <returns>The amount to be paid for the Desk</returns>
        public int calcQuote()
        {
            return BASE_DESK_PRICE + calcSizeCost() + calcMaterial() + calcDrawer() + calcShippingCost();
        }
    }
}
