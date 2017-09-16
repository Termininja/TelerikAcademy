// -----------------------------------------------------------------------------
// <copyright file="IMotherboard.cs" company="Telerik">
// Telerik Academy 2014
// </copyright>
// <summary>
// Defines a computer motherboard interface
// </summary>
// -----------------------------------------------------------------------------

namespace Computers
{
    /// <summary>
    /// This interface can load values from the RAM, save values to the RAM and draw on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// This method load values from the RAM.
        /// </summary>
        /// <returns>Returns int.</returns>
        int LoadRamValue();

        /// <summary>
        /// This method save values to the RAM.
        /// </summary>
        /// <param name="value">The value.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// This method draw some data on the video card.
        /// </summary>
        /// <param name="data">The data.</param>
        void DrawOnVideoCard(string data);
    }
}