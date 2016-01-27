namespace BattleOfTheMachines.WebForms.Helpers
{
    using System;

    public static class ImageHelper
    {
        public static string GetComponentUrl(byte[] image)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(image);
        }
    }
}